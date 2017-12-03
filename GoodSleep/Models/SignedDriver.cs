namespace GoodSleep.Models
{
    public class SignedDriver : IDriver
    {
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
