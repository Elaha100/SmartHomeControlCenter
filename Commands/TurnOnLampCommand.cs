using SmartHomeControlCenter.Devices;

namespace SmartHomeControlCenter.Commands
{
    public class TurnOnLampCommand : ICommand
    {
        private readonly Lamp _lamp;
        public string Name => $"TurnOnLamp({_lamp.Name})";

        public TurnOnLampCommand(Lamp lamp)
        {
            _lamp = lamp;
        }

        public void Execute()
        {
            _lamp.TurnOn();
        }
    }
}