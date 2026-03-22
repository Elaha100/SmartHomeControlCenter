using SmartHomeControlCenter.Core;

namespace SmartHomeControlCenter.Devices
{
    public class Thermostat : IDevice, ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        public string Name { get; }
        public int Temperature { get; private set; }

        public Thermostat(string name, int startTemperature = 21)
        {
            Name = name;
            Temperature = startTemperature;
        }

        public void SetTemperature(int temperature)
        {
            Temperature = temperature;
            Notify(new DeviceEvent(Name, "SetTemperature", $"Temperaturen satt till {Temperature}°C"));
        }

        public string GetStatus()
        {
            return $"{Name}: {Temperature}°C";
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(DeviceEvent deviceEvent)
        {
            foreach (var observer in _observers)
            {
                observer.Update(deviceEvent);
            }
        }
    }
}