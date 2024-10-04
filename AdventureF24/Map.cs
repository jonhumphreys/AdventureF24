namespace AdventureF24;

public static class Map
{
    public static Location StartLocation;
    
    public static void Initialize()
    {
        Location entranceHall = new Location("Entrance Hall",
            "A grand hall.  Doors lead north and east.");
        Location library = new Location("Library",
            "Books and more books.  A door leads south.");
        Location storageRoom = new Location("Storage Room",
             "Dusty and full of debris.  Doors lead west and north.");
        Location treasureRoom = new Location("Treasure Room",
             "Dimly lit, a chest sits in the corner.  There is an exit to the south.");
        Location hole = new Location("Hole",
            "Maybe you shouldn't have come down here.  There's no way out.");
        
        entranceHall.AddConnection("north", library);
        entranceHall.AddConnection("east", storageRoom);
        entranceHall.AddConnection("down", hole);
        library.AddConnection("south", entranceHall);
        storageRoom.AddConnection("north", treasureRoom);
        storageRoom.AddConnection("west", entranceHall);
        treasureRoom.AddConnection("south", storageRoom);
        
        StartLocation = entranceHall;

        Item key = new Item("Key", "An old, rusty, comically oversized key.", "There is a key here.");
        entranceHall.AddItem(key);
        
        Item beer = new Item("Beer", "Beer's beer.", "There is a beer here.");
        entranceHall.AddItem(beer);
    }
}