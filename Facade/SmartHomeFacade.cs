using SmartHomeControlCenter.Commands;
using SmartHomeControlCenter.Core;
using SmartHomeControlCenter.Devices;
using SmartHomeControlCenter.Observers;
using SmartHomeControlCenter.Strategy;

namespace SmartHomeControlCenter.Facade
{
    public class SmartHomeFacade
    {
        private readonly List<IDevice> _devices = new List<IDevice>();
        private readonly List<Lamp> _lamps = new List<Lamp>();
        private readonly CommandInvoker _invoker = new CommandInvoker();

        public IModeStrategy CurrentMode { get; private set; }

        public SmartHomeFacade()
        {
            CurrentMode = new NormalModeStrategy();
        }

        public void AddDevice(IDevice device)
        {
            _devices.Add(device);

            if (device is Lamp lamp)
            {
                _lamps.Add(lamp);
            }

            Console.WriteLine($"[FACADE] Enhet tillagd: {device.Name}");
        }

        public void SetMode(IModeStrategy mode)
        {
            CurrentMode = mode;
            Console.WriteLine($"[FACADE] System mode ändrad till: {CurrentMode.Name}");
        }

        public void RunCommand(ICommand command)
        {
            if (command is TurnOnAllLightsCommand && !CurrentMode.CanTurnOnAllLights())
            {
                Console.WriteLine($"[FACADE] Blockerat av {CurrentMode.Name}-läge: kan inte tända alla lampor.");
                return;
            }

            if (command is UnlockDoorCommand && !CurrentMode.CanUnlockDoor())
            {
                Console.WriteLine($"[FACADE] Blockerat av {CurrentMode.Name}-läge: dörren får inte låsas upp.");
                return;
            }

            if (command is SetTemperatureCommand setTemperatureCommand)
            {
                int original = setTemperatureCommand.RequestedTemperature;
                int adjusted = CurrentMode.AdjustTemperature(original);

                if (original != adjusted)
                {
                    Console.WriteLine($"[FACADE] {CurrentMode.Name}-läge justerade temperaturen från {original} till {adjusted}.");
                    setTemperatureCommand.RequestedTemperature = adjusted;
                }
            }

            _invoker.ExecuteCommand(command);
        }

        public void MorningRoutine(Lamp lamp, Thermostat thermostat, DoorLock doorLock)
        {
            Console.WriteLine("\n[FACADE] MorningRoutine startar...");

            RunCommand(new UnlockDoorCommand(doorLock));
            RunCommand(new TurnOnLampCommand(lamp));
            RunCommand(new SetTemperatureCommand(thermostat, 21));
        }

        public void ShowAllStatuses()
        {
            Console.WriteLine("\n===== STATUS =====");
            foreach (var device in _devices)
            {
                Console.WriteLine(device.GetStatus());
            }
        }

        public void ShowCommandHistory()
        {
            _invoker.PrintHistory();
        }

        public void ReplayLastFiveCommands()
        {
            _invoker.ReplayLastFive();
        }

        public void ShowSingletonProof(LoggerObserver loggerObserver)
        {
            Console.WriteLine("\n===== SINGLETON BEVIS =====");
            Console.WriteLine($"LoggerObserver Logger ID: {loggerObserver.GetLoggerInstanceId()}");
            Console.WriteLine($"CommandInvoker Logger ID: {_invoker.GetLoggerInstanceId()}");
        }

        public List<Lamp> GetAllLamps()
        {
            return _lamps;
        }
    }
}