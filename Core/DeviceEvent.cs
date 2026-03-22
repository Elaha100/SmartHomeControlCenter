namespace SmartHomeControlCenter.Core
{
    public class DeviceEvent
    {
        public string DeviceName { get; }
        public string Action { get; }
        public string Details { get; }
        public DateTime Timestamp { get; }

        public DeviceEvent(string deviceName, string action, string details)
        {
            DeviceName = deviceName;
            Action = action;
            Details = details;
            Timestamp = DateTime.Now;
        }
    }
}