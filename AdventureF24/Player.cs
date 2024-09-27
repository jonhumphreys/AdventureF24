namespace AdventureF24;

public static class Player
{
    private static Location currentLocation;

    public static void Initialize()
    {
        currentLocation = Map.StartLocation;
        IO.Write(currentLocation.GetDescription());
    }
    
    public static void Move(Command command)
    {
        if (currentLocation.CanMoveInDirection(command.Noun))
        {
            currentLocation = currentLocation.GetLocationInDirection(command.Noun);
            IO.Write(currentLocation.GetDescription());
        }
        else
        {
            IO.Write("Can't go that way.");
        }
    }
}