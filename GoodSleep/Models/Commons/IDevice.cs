namespace GoodSleep.Models
{
    public interface IDevice : IDriver
    {
        string Name { get; }

        bool IsWakeEnabled { get; }

        bool IsWakeProgrammable { get; }
    }
}
