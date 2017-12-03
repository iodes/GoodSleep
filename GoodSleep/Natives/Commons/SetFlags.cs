using System;

namespace GoodSleep.Natives
{
    [Flags]
    public enum SetFlags : uint
    {
        /// <summary>
        /// Enables the specified device to wake the system.
        /// </summary>
        DEVICEPOWER_SET_WAKEENABLED = 0x00000001,

        /// <summary>
        /// Stops the specified device from being able to wake the system.
        /// </summary>
        DEVICEPOWER_CLEAR_WAKEENABLED = 0x00000002,
    }
}
