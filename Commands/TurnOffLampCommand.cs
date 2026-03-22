using SmartHomeControlCenter.Devices;

namespace SmartHomeControlCenter.Commands
{
    public class TurnOffLampCommand : ICommand
    {
        private readonly Lamp _lamp;
        public string Name => $"TurnOffLamp({_lamp.Name})";

        public TurnOffLampCommand(Lamp lamp)
        {
            _lamp = lamp;
        }

        public void Execute()
        {
            _lamp.TurnOff();
        }
    }
}