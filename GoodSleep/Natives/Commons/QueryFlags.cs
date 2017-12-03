using System;

namespace GoodSleep.Natives
{
    [Flags]
    public enum QueryFlags : uint
    {
        /// <summary>
        /// The device supports system power state D0.
        /// </summary>
        PDCAP_D0_SUPPORTED = 0x00000001,

        /// <summary>
        /// The device supports system power state D1.
        /// </summary>
        PDCAP_D1_SUPPORTED = 0x00000002,

        /// <summary>
        /// The device supports system power state D2.
        /// </summary>
        PDCAP_D2_SUPPORTED = 0x00000004,

        /// <summary>
        /// The device supports system power state D3.
        /// </summary>
        PDCAP_D3_SUPPORTED = 0x00000008,

        /// <summary>
        /// The device supports system sleep state S0.
        /// </summary>
        PDCAP_S0_SUPPORTED = 0x00010000,

        /// <summary>
        /// The device supports system sleep state S1.
        /// </summary>
        PDCAP_S1_SUPPORTED = 0x00020000,

        /// <summary>
        /// The device supports system sleep state S2.
        /// </summary>
        PDCAP_S2_SUPPORTED = 0x00040000,

        /// <summary>
        /// The device supports system sleep state S3.
        /// </summary>
        PDCAP_S3_SUPPORTED = 0x00080000,

        /// <summary>
        /// The device supports system sleep state S4.
        /// </summary>
        PDCAP_S4_SUPPORTED = 0x01000000,

        /// <summary>
        /// The device supports system sleep state S5.
        /// </summary>
        PDCAP_S5_SUPPORTED = 0x02000000,

        /// <summary>
        /// The device supports waking from system power state D0.
        /// </summary>
        PDCAP_WAKE_FROM_D0_SUPPORTED = 0x00000010,

        /// <summary>
        /// The device supports waking from system power state D1.
        /// </summary>
        PDCAP_WAKE_FROM_D1_SUPPORTED = 0x00000020,

        /// <summary>
        /// The device supports waking from system power state D2.
        /// </summary>
        PDCAP_WAKE_FROM_D2_SUPPORTED = 0x00000040,

        /// <summary>
        /// The device supports waking from system power state D3.
        /// </summary>
        PDCAP_WAKE_FROM_D3_SUPPORTED = 0x00000080,

        /// <summary>
        /// The device supports waking from system sleep state S0.
        /// </summary>
        PDCAP_WAKE_FROM_S0_SUPPORTED = 0x00100000,

        /// <summary>
        /// The device supports waking from system sleep state S1.
        /// </summary>
        PDCAP_WAKE_FROM_S1_SUPPORTED = 0x00200000,

        /// <summary>
        /// The device supports waking from system sleep state S2.
        /// </summary>
        PDCAP_WAKE_FROM_S2_SUPPORTED = 0x00400000,

        /// <summary>
        /// The device supports waking from system sleep state S3.
        /// </summary>
        PDCAP_WAKE_FROM_S3_SUPPORTED = 0x00800000,

        /// <summary>
        /// The device supports warm eject.
        /// </summary>
        PDCAP_WARM_EJECT_SUPPORTED = 0x00000100,
    }
}
