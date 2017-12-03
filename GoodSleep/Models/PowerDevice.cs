namespace GoodSleep.Models
{
    public class PowerDevice : IDevice
    {
        public string Name { get; internal set; }

        public bool IsWakeEnabled { get; internal set; }

        public bool IsWakeProgrammable { get; internal set; }

        public string ClassGuid { get; internal set; }

        public string Description { get; internal set; }

        public string DeviceID { get; internal set; }

        public string DeviceName { get; internal set; }

        public string FriendlyName { get; internal set; }

        public string HardWareID { get; internal set; }

        public string Location { get; internal set; }

        public string Manufacturer { get; internal set; }
    }
}
