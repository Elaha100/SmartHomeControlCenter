using SmartHomeControlCenter.Devices;

namespace SmartHomeControlCenter.Commands
{
    public class SetTemperatureCommand : ICommand
    {
        private readonly Thermostat _thermostat;
        public int RequestedTemperature { get; set; }
        public string Name => $"SetTemperature({_thermostat.Name}, {RequestedTemperature})";

        public SetTemperatureCommand(Thermostat thermostat, int requestedTemperature)
        {
            _thermostat = thermostat;
            RequestedTemperature = requestedTemperature;
        }

        public void Execute()
        {
            _thermostat.SetTemperature(RequestedTemperature);
        }
    }
}