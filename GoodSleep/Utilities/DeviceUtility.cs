using GoodSleep.Models;
using GoodSleep.Natives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace GoodSleep.Utilities
{
    public static class DeviceUtility
    {
        #region 상수
        private const QueryFlags flagsQuery =
            QueryFlags.PDCAP_WAKE_FROM_S0_SUPPORTED |
            QueryFlags.PDCAP_WAKE_FROM_S1_SUPPORTED |
            QueryFlags.PDCAP_WAKE_FROM_S2_SUPPORTED |
            QueryFlags.PDCAP_WAKE_FROM_S3_SUPPORTED;

        private const QueryInterpretationFlags flagsAll =
            QueryInterpretationFlags.DEVICEPOWER_FILTER_DEVICES_PRESENT |
            QueryInterpretationFlags.DEVICEPOWER_HARDWAREID;

        private const QueryInterpretationFlags flagsAllName =
            QueryInterpretationFlags.DEVICEPOWER_FILTER_DEVICES_PRESENT;

        private const QueryInterpretationFlags flagsWakeEnabled =
            QueryInterpretationFlags.DEVICEPOWER_FILTER_WAKEENABLED |
            QueryInterpretationFlags.DEVICEPOWER_HARDWAREID;
        #endregion

        #region 내부 함수
        private static bool TryGetDevice(uint index, out string result, QueryInterpretationFlags? flags = null)
        {
            uint size = 0;
            QueryInterpretationFlags targetFlags = flags ?? flagsAll;
            PowerManagement.DevicePowerEnumDevices(index, targetFlags, flagsQuery, IntPtr.Zero, ref size);

            if (size > 0)
            {
                var buffer = Marshal.AllocHGlobal((int)size);

                try
                {
                    if (PowerManagement.DevicePowerEnumDevices(index, targetFlags, flagsQuery, buffer, ref size) && buffer != IntPtr.Zero)
                    {
                        result = Marshal.PtrToStringUni(buffer);
                        return true;
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }

            result = null;
            return false;
        }

        private static IReadOnlyList<string> GetWakeEnabledDevices()
        {
            var result = new List<string>();

            if (PowerManagement.DevicePowerOpen(0))
            {
                try
                {
                    uint index = 0;
                    string lastDevice = null;
                    while (TryGetDevice(index, out lastDevice, flagsWakeEnabled))
                    {
                        result.Add(lastDevice);
                        index++;
                    }
                }
                finally
                {
                    PowerManagement.DevicePowerClose();
                }
            }

            return result;
        }

        private static IReadOnlyList<string> GetWakeProgrammableDevices()
        {
            var powercfg = new Process();

            powercfg.StartInfo.CreateNoWindow = true;
            powercfg.StartInfo.UseShellExecute = false;
            powercfg.StartInfo.RedirectStandardOutput = true;
            powercfg.StartInfo.FileName = "powercfg";
            powercfg.StartInfo.Arguments = "/devicequery wake_programmable";
            powercfg.Start();

            string output = powercfg.StandardOutput.ReadToEnd();
            powercfg.WaitForExit();

            if (output.Length > 0)
            {
                return output.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            }

            return null;
        }
        #endregion

        #region 사용자 함수
        public static IReadOnlyList<PowerDevice> GetPowerDevices()
        {
            var result = new List<PowerDevice>();

            if (PowerManagement.DevicePowerOpen(0))
            {
                var wakeEnabledDevices = GetWakeEnabledDevices();
                var wakeProgrammableDevices = GetWakeProgrammableDevices();
                var signedDrivers = DriverUtility.GetSignedDrivers();

                try
                {
                    uint index = 0;
                    string lastDevice = null;
                    while (TryGetDevice(index, out lastDevice))
                    {
                        var driver = signedDrivers.Where(x => x.HardWareID == lastDevice).FirstOrDefault();

                        if (driver != null)
                        {
                            TryGetDevice(index, out string name, flagsAllName);

                            var powerDevice = new PowerDevice
                            {
                                ClassGuid = driver.ClassGuid,
                                Description = driver.Description,
                                DeviceID = driver.DeviceID,
                                DeviceName = driver.DeviceName,
                                FriendlyName = driver.FriendlyName,
                                HardWareID = driver.HardWareID,
                                IsWakeEnabled = wakeEnabledDevices.Contains(driver.HardWareID),
                                IsWakeProgrammable = wakeProgrammableDevices.Contains(name),
                                Location = driver.Location,
                                Manufacturer = driver.Manufacturer,
                                Name = name
                            };

                            result.Add(powerDevice);
                        }

                        index++;
                    }
                }
                finally
                {
                    PowerManagement.DevicePowerClose();
                }
            }

            return result;
        }

        public async static Task<IReadOnlyList<PowerDevice>> GetPowerDevicesAsync()
        {
            return await Task.Run(() => GetPowerDevices());
        }

        public static bool SetDeviceState(PowerDevice device, bool value)
        {
            return PowerManagement.DevicePowerSetDeviceState(device.Name, value ? SetFlags.DEVICEPOWER_SET_WAKEENABLED : SetFlags.DEVICEPOWER_CLEAR_WAKEENABLED, IntPtr.Zero) == 0;
        }

        public async static Task<bool> SetDeviceStateAsync(PowerDevice device, bool value)
        {
            return await Task.Run(() => SetDeviceState(device, value));
        }

        public static void ShowProperty(PowerDevice device)
        {
            Process.Start("Rundll32", $@"devmgr.dll,DeviceProperties_RunDLL /DeviceID ""{device.DeviceID}""");
        }
        #endregion
    }
}
