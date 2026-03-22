using SmartHomeControlCenter.Core;

namespace SmartHomeControlCenter.Devices
{
    public class DoorLock : IDevice, ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        public string Name { get; }
        public bool IsLocked { get; private set; } = true;

        public DoorLock(string name)
        {
            Name = name;
        }

        public void Lock()
        {
            IsLocked = true;
            Notify(new DeviceEvent(Name, "Lock", "Dörren är nu låst"));
        }

        public void Unlock()
        {
            IsLocked = false;
            Notify(new DeviceEvent(Name, "Unlock", "Dörren är nu upplåst"));
        }

        public string GetStatus()
        {
            return $"{Name}: {(IsLocked ? "Låst" : "Upplåst")}";
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