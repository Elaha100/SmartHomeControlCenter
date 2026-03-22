using SmartHomeControlCenter.Core;

namespace SmartHomeControlCenter.Observers
{
    public class AuditObserver : IObserver
    {
        public void Update(DeviceEvent deviceEvent)
        {
            Console.WriteLine($"[AUDIT] {deviceEvent.Timestamp:HH:mm:ss} | {deviceEvent.DeviceName} | {deviceEvent.Action}");
        }
    }
}