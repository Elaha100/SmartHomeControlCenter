using SmartHomeControlCenter.Devices;

namespace SmartHomeControlCenter.Commands
{
    public class LockDoorCommand : ICommand
    {
        private readonly DoorLock _doorLock;
        public string Name => $"LockDoor({_doorLock.Name})";

        public LockDoorCommand(DoorLock doorLock)
        {
            _doorLock = doorLock;
        }

        public void Execute()
        {
            _doorLock.Lock();
        }
    }
}