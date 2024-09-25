namespace AdventureF24;

public static class Map
{
    public static void Initialize()
    {
        Location entranceHall = new Location("Entrance Hall",
            "A grand hall.  Doors lead north and east.");
        Location library = new Location("Library",
            "Books and more books.  A door leads south.");
        
        entranceHall.AddConnection("north", library);
        library.AddConnection("south", entranceHall);
    }
}