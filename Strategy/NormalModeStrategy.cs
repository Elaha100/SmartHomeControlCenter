namespace SmartHomeControlCenter.Strategy
{
    public class NormalModeStrategy : IModeStrategy
    {
        public string Name => "Normal";

        public bool CanTurnOnAllLights()
        {
            return true;
        }

        public bool CanUnlockDoor()
        {
            return true;
        }

        public int AdjustTemperature(int requestedTemperature)
        {
            return requestedTemperature;
        }
    }
}