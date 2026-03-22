namespace SmartHomeControlCenter.Strategy
{
    public class PartyModeStrategy : IModeStrategy
    {
        public string Name => "Party";

        public bool CanTurnOnAllLights()
        {
            return true;
        }

        public bool CanUnlockDoor()
        {
            return false;
        }

        public int AdjustTemperature(int requestedTemperature)
        {
            return requestedTemperature < 24 ? 24 : requestedTemperature;
        }
    }
}