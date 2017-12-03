using GoodSleep.Models;
using System.Collections.Generic;
using System.Management;

namespace GoodSleep.Utilities
{
    public static class DriverUtility
    {
        #region 상수
        private const string scope = "root\\CIMV2";
        private const string query = "SELECT * FROM Win32_PnPSignedDriver";
        #endregion

        #region 사용자 함수
        public static IReadOnlyList<SignedDriver> GetSignedDrivers()
        {
            var result = new List<SignedDriver>();
            var searcher = new ManagementObjectSearcher(scope, query);

            foreach (var queryObj in searcher.Get())
            {
                var driver = new SignedDriver
                {
                    ClassGuid = queryObj[nameof(IDriver.ClassGuid)]?.ToString(),
                    Description = queryObj[nameof(IDriver.Description)]?.ToString(),
                    DeviceID = queryObj[nameof(IDriver.DeviceID)]?.ToString(),
                    DeviceName = queryObj[nameof(IDriver.DeviceName)]?.ToString(),
                    FriendlyName = queryObj[nameof(IDriver.FriendlyName)]?.ToString(),
                    HardWareID = queryObj[nameof(IDriver.HardWareID)]?.ToString(),
                    Location = queryObj[nameof(IDriver.Location)]?.ToString(),
                    Manufacturer = queryObj[nameof(IDriver.Manufacturer)]?.ToString(),
                };

                result.Add(driver);
            }

            return result;
        }
        #endregion
    }
}
