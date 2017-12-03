using System;
using System.Runtime.InteropServices;

namespace GoodSleep.Natives
{
    public static class PowerManagement
    {
        [DllImport("powrprof.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DevicePowerOpen(uint flags);

        [DllImport("powrprof.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DevicePowerClose();

        [DllImport("powrprof.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DevicePowerEnumDevices(uint queryIndex, QueryInterpretationFlags queryInterpretationFlags, QueryFlags queryFlags, IntPtr pReturnBuffer, ref uint pBufferSize);

        [DllImport("powrprof.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int DevicePowerSetDeviceState(string deviceDescription, SetFlags setFlags, IntPtr setData);
    }
}
