using SmartHomeControlCenter.Core;

namespace SmartHomeControlCenter.Devices
{
    public class Lamp : IDevice, ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        public string Name { get; }
        public bool IsOn { get; private set; }

        public Lamp(string name)
        {
            Name = name;
        }

        public void TurnOn()
        {
            IsOn = true;
            Notify(new DeviceEvent(Name, "TurnOn", "Lampan är nu PÅ"));
        }

        public void TurnOff()
        {
            IsOn = false;
            Notify(new DeviceEvent(Name, "TurnOff", "Lampan är nu AV"));
        }

        public string GetStatus()
        {
            return $"{Name}: {(IsOn ? "På" : "Av")}";
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