namespace AdventureF24;

public class Location
{
    public string Name;
    
    public string Description;

    public Dictionary<string, Location> Connections;

    public Location(string name, string description)
    {
        Name = name;
        Description = description;
        Connections = new Dictionary<string, Location>();
    }

    public void AddConnection(string direction, Location location)
    {
        Connections.Add(direction, location);
    }

    public bool CanMoveInDirection(string direction)
    {
        return Connections.ContainsKey(direction);
    }

    public Location GetLocationInDirection(string direction)
    {
        return Connections[direction];
    }

    public string GetDescription()
    {
         return Name + "\n" + Description;
    }
}