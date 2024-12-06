using System.Text.Json;

namespace AdventureF24;


public static class Map
{
    public static Location StartLocation;
    private static Dictionary<string, Location> nameToLocation = new Dictionary<string, Location>();
    
    public static void Initialize()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Locations.json");
        string rawText = File.ReadAllText(path);
        
        // convert the text to ItemsJsonData
        MapJsonData? data = JsonSerializer.Deserialize<MapJsonData>(rawText);

        // Add all locations
        Dictionary<string, Location> locations = new Dictionary<string, Location>();
        foreach (LocationJsonData location in data.Locations)
        {
            Location newLocation = AddLocation(location.Name, location.Description);
            locations.Add(location.Name, newLocation);
        }
        
        // Create all connections
        foreach (LocationJsonData location in data.Locations)
        {
            Location currentLocation = locations[location.Name];
            foreach (KeyValuePair<string, string> connection in location.Connections)
            {
                string direction = connection.Key.ToLower();
                string destination = connection.Value;

                if (locations.TryGetValue(destination, out Location connectionedLocation))
                {
                    currentLocation.AddConnection(direction, connectionedLocation);
                }
                else
                {
                    IO.Error("Location " + location.Name + " does not exist.");
                }
            }
        }

        if (locations.TryGetValue(data.StartLocation, out Location startLocation))
        {
            StartLocation = startLocation;
        }
        else
        {
            IO.Error("Location");
        }
      
    }

    public static void AddConnection(string startLocationName, string direction, string endLocationName)
    {
        Location? start = FindLocation(startLocationName);
        Location? end = FindLocation(endLocationName);
        if (start == null || end == null)
        {
            IO.Error("Could not find location: " +  startLocationName + 
                     "and/or " + endLocationName + ".");
            return;
        }
        
        start.AddConnection(direction, end);
    }

    public static void RemoveConnection(string locationName, string direction)
    {
        Location? location = FindLocation(locationName);
        if (location == null)
        {
            IO.Error("Could not find location: " + locationName + ".");
            return;
        }

        location.RemoveConnection(direction);
    }

    public static Location? FindLocation(string locationName)
    {
        if (nameToLocation.ContainsKey(locationName))
            return nameToLocation[locationName];
        return null;
    }

    private static Location AddLocation(string name, string description)
    {
        Location location = new Location(name, description);
        nameToLocation.Add(name, location);

        return location;
    }

    public static bool DoesLocationExist(string locationName)
    {
        if (FindLocation(locationName) != null)
        {
            return true;
        }

        return false;
    }

    public static Location GetLocationByName(string locationName)
    {
        Location? location = FindLocation(locationName);
        return location;
    }

    public static void AddItem(ItemType itemType, string locationName)
    {
        Item? item = Items.FindItem(itemType);
        AddItem(item, locationName);
    }

    public static void AddItem(Item? item, string roomName)
    {
        Location? location = GetLocationByName(roomName);
        if (location == null || item == null)
        {
            return;
        }
        AddItemToLocation(item, location);
    }

    private static void AddItemToLocation(Item item, Location location)
    {
        location.AddItem(item);
    }

    public static void RemoveItem(ItemType itemType, string locationName)
    {
        Location? location = GetLocationByName(locationName);
        if (location == null)
        {
            return;
        }
        location.RemoveItem(itemType);
    }
}