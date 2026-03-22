using SmartHomeControlCenter.Commands;
using SmartHomeControlCenter.Devices;
using SmartHomeControlCenter.Facade;
using SmartHomeControlCenter.Observers;
using SmartHomeControlCenter.Strategy;
using SmartHomeControlCenter.Core;

namespace SmartHomeControlCenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hub = new SmartHomeFacade();

            var lamp = new Lamp("Living Room Lamp");
            var thermostat = new Thermostat("Main Thermostat");
            var doorLock = new DoorLock("Front Door");

            var dashboard = new DashboardObserver();
            var loggerObserver = new LoggerObserver();
            var audit = new AuditObserver();

            lamp.Attach(dashboard);
            lamp.Attach(loggerObserver);
            lamp.Attach(audit);

            thermostat.Attach(dashboard);
            thermostat.Attach(loggerObserver);
            thermostat.Attach(audit);

            doorLock.Attach(dashboard);
            doorLock.Attach(loggerObserver);
            doorLock.Attach(audit);

            hub.AddDevice(lamp);
            hub.AddDevice(thermostat);
            hub.AddDevice(doorLock);

            Console.WriteLine("===== SMART HOME CONTROL CENTER =====");

            hub.ShowSingletonProof(loggerObserver);

            Console.WriteLine("\n===== NORMAL MODE =====");
            hub.SetMode(new NormalModeStrategy());
            hub.RunCommand(new TurnOnLampCommand(lamp));
            hub.RunCommand(new SetTemperatureCommand(thermostat, 23));
            hub.RunCommand(new UnlockDoorCommand(doorLock));

            Console.WriteLine("\n===== ECO MODE =====");
            hub.SetMode(new EcoModeStrategy());
            hub.RunCommand(new SetTemperatureCommand(thermostat, 25));
            hub.RunCommand(new TurnOnAllLightsCommand(hub.GetAllLamps()));

            Console.WriteLine("\n===== PARTY MODE =====");
            hub.SetMode(new PartyModeStrategy());
            hub.RunCommand(new TurnOnAllLightsCommand(hub.GetAllLamps()));
            hub.RunCommand(new UnlockDoorCommand(doorLock));

            Console.WriteLine("\n===== MORNING ROUTINE =====");
            hub.SetMode(new NormalModeStrategy());
            hub.MorningRoutine(lamp, thermostat, doorLock);

            hub.ShowAllStatuses();
            hub.ShowCommandHistory();
            hub.ReplayLastFiveCommands();

            Logger.Instance.PrintAllLogs();

            Console.WriteLine("\nKlart. Tryck på valfri tangent för att avsluta.");
            Console.ReadKey();
        }
    }
}