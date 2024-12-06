using System.Data;

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
    
    public static Action AddItemToInventory(ItemType itemType)
    {
        return () => Player.AddToInventory(itemType);
    }
    
    public static Action RemoveItemFromInventory(ItemType itemType)
    {
        return () => Player.RemoveItemFromInventory(itemType);
    }

    public static Action AddItemToLocation(ItemType itemType, string locationName)
    {
        return () => Map.AddItem(itemType, locationName);
    }
    
    public static Action RemoveItemFromLocation(ItemType itemType, string locationName)
    {
        return () => Map.RemoveItem(itemType, locationName);
    }

    public static Action WinGame()
    {
        return () => Game.WinGame();
    }
    
    // if player dies
    
    // spawn mob
    
    // remove mob
    
    // change state
}