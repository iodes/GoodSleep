namespace GoodSleep.Models
{
    public interface IDriver
    {
        string ClassGuid { get; }

        string Description { get; }

        string DeviceID { get; }

        string DeviceName { get; }

        string FriendlyName { get; }

        string HardWareID { get; }

        string Location { get; }

        string Manufacturer { get; }
    }
}
