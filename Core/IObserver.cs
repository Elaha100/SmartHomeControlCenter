namespace SmartHomeControlCenter.Core
{
    public interface IObserver
    {
        void Update(DeviceEvent deviceEvent);
    }
}