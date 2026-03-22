using SmartHomeControlCenter.Core;

namespace SmartHomeControlCenter.Observers
{
    public class LoggerObserver : IObserver
    {
        private readonly Logger _logger;

        public LoggerObserver()
        {
            _logger = Logger.Instance;
        }

        public void Update(DeviceEvent deviceEvent)
        {
            _logger.Log($"{deviceEvent.DeviceName} -> {deviceEvent.Action} | {deviceEvent.Details}");
        }

        public int GetLoggerInstanceId()
        {
            return _logger.GetInstanceId();
        }
    }
}