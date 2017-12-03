using System;

namespace GoodSleep.Natives
{
    [Flags]
    public enum QueryInterpretationFlags : uint
    {
        /// <summary>
        /// Return a hardware ID string rather than friendly device name.
        /// </summary>
        DEVICEPOWER_HARDWAREID = 0x80000000,

        /// <summary>
        /// Ignore devices not currently present in the system.
        /// </summary>
        DEVICEPOWER_FILTER_DEVICES_PRESENT = 0x20000000,

        /// <summary>
        /// Perform an AND operation on QueryFlags.
        /// </summary>
        DEVICEPOWER_AND_OPERATION = 0x40000000,

        /// <summary>
        /// Check whether the device is currently enabled to wake the system from a sleep state.
        /// </summary>
        DEVICEPOWER_FILTER_WAKEENABLED = 0x08000000,

        /// <summary>
        /// Find a device whose name matches the string passed in pReturnBuffer and check its capabilities against QueryFlags.
        /// </summary>
        DEVICEPOWER_FILTER_ON_NAME = 0x02000000,
    }
}
