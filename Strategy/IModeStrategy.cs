namespace SmartHomeControlCenter.Strategy
{
    public interface IModeStrategy
    {
        string Name { get; }
        bool CanTurnOnAllLights();
        bool CanUnlockDoor();
        int AdjustTemperature(int requestedTemperature);
    }
}