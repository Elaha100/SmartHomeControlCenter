using SmartHomeControlCenter.Devices;

namespace SmartHomeControlCenter.Commands
{
    public class UnlockDoorCommand : ICommand
    {
        private readonly DoorLock _doorLock;
        public string Name => $"UnlockDoor({_doorLock.Name})";

        public UnlockDoorCommand(DoorLock doorLock)
        {
            _doorLock = doorLock;
        }

        public void Execute()
        {
            _doorLock.Unlock();
        }
    }
}