namespace AdventureF24;

public static class ConditionActions
{
    public static Action WriteOutput(string message)
    {
        return () => IO.WriteLine(message);
    }
    
    public static Action AddMapConnection(string startLocationName,
        string direction, string endLocationName)
    {
        return () => Map.AddConnection(startLocationName, direction, endLocationName);
    }
    
    public static Action RemoveMapConnection(string locationName, string direction)
    {
        return () => Map.RemoveConnection(locationName, direction);
    }
    
    public static Action MovePlayerToLocation(string locationName)
    {
        return () => Player.MoveToLocation(locationName);
    }
    
    // if player dies
    
    // add item to inventory
    
    // add item to room
    
    // remove item from inventory
    
    // remove item from room
    
    // spawn mob
    
    // remove mob
    
    // change state
}