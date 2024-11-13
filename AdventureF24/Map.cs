namespace AdventureF24;

public static class Map
{
    public static Location StartLocation;
    
    private static Dictionary<string, Location> nameToLocation = 
        new Dictionary<string, Location>();
    
    public static void Initialize()
    {
        Location entranceHall = AddLocation("Entrance Hall",
            "A grand hall.  Doors lead north and east.");
        Location library = AddLocation("Library",
            "Books and more books.  A door leads south.");
        Location storageRoom = AddLocation("Storage Room",
             "Dusty and full of debris.  Doors lead west and north.");
        Location treasureRoom = AddLocation("Treasure Room",
             "Dimly lit, a chest sits in the corner.  There is an exit to the south.");
        Location hole = AddLocation("Hole",
            "Maybe you shouldn't have come down here.  There's no way out.");
        
        entranceHall.AddConnection("north", library);
        entranceHall.AddConnection("east", storageRoom);
        entranceHall.AddConnection("down", hole);
        library.AddConnection("south", entranceHall);
        storageRoom.AddConnection("north", treasureRoom);
        storageRoom.AddConnection("west", entranceHall);
        treasureRoom.AddConnection("south", storageRoom);
        
        StartLocation = entranceHall;

        Item key = new Item("Key", "An old, rusty, comically oversized key.", "There is a key poking out from the dust.");
        entranceHall.AddItem(key);
        
        Item beer = new Item("Beer", "Beer's beer.", "There is a beer sitting on the ground.");
        entranceHall.AddItem(beer);
        
        Item gator = new Item("Alligator", "Alligator's beer.", "There is a smiling alligator.");
        entranceHall.AddItem(gator);
    }

    private static Location AddLocation(string name, string description)
    {
        Location location = new Location(name, description);
        nameToLocation.Add(name, location);
        
        return location;
    }

    public static void AddConnection(string startLocation,
        string direction, string endLocation)
    {
        Location? start = FindLocation(startLocation);
        Location? end = FindLocation(endLocation);

        if (start == null || end == null)
        {
            IO.Error("Could not find location: " + 
                     startLocation + " and/or " + endLocation);
            return;
        }

        start.AddConnection(direction, end);
    }

    public static void RemoveConnection(string locationName, string direction)
    {
        Location? location = FindLocation(locationName);

        if (location == null)
            return;
        
        location.RemoveConnection(direction);
    }

    public static Location? FindLocation(string location)
    {   
        if (nameToLocation.ContainsKey(location))
            return nameToLocation[location];
        return null;
    }

    public static bool DoesLocationExist(string locationName)
    {
        if (FindLocation(locationName) != null)
            return true;
        return false;
    }

    public static Location? GetLocationByName(string locationName)
    {
        Location? location = FindLocation(locationName);
        return location;
    }
}