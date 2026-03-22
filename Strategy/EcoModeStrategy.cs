namespace SmartHomeControlCenter.Strategy
{
    public class EcoModeStrategy : IModeStrategy
    {
        public string Name => "Eco";

        public bool CanTurnOnAllLights()
        {
            return false;
        }

        public bool CanUnlockDoor()
        {
            return true;
        }

        public int AdjustTemperature(int requestedTemperature)
        {
            return requestedTemperature > 22 ? 22 : requestedTemperature;
        }
    }
}