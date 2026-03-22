namespace SmartHomeControlCenter.Devices
{
    public interface IDevice
    {
        string Name { get; }
        string GetStatus();
    }
}