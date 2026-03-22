using SmartHomeControlCenter.Core;

namespace SmartHomeControlCenter.Observers
{
    public class DashboardObserver : IObserver
    {
        public void Update(DeviceEvent deviceEvent)
        {
            Console.WriteLine($"[DASHBOARD] {deviceEvent.DeviceName} -> {deviceEvent.Action} | {deviceEvent.Details}");
        }
    }
}