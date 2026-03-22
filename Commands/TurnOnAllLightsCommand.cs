using SmartHomeControlCenter.Devices;

namespace SmartHomeControlCenter.Commands
{
    public class TurnOnAllLightsCommand : ICommand
    {
        private readonly List<Lamp> _lamps;
        public string Name => "TurnOnAllLights";

        public TurnOnAllLightsCommand(List<Lamp> lamps)
        {
            _lamps = lamps;
        }

        public void Execute()
        {
            foreach (var lamp in _lamps)
            {
                lamp.TurnOn();
            }
        }
    }
}