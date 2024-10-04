namespace AdventureF24;

public static class Player
{
    private static Location currentLocation;
    public static List<Item> Inventory;

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

    public static void Take(Command command)
    {
        IO.Write("taking " + command.Noun);

        Item item = currentLocation.FindItem(command.Noun);

        if (item == null)
        {
            IO.Write("There is no " + command.Noun + " here.");
        }
        else if (!item.IsTakeable)
        {
            IO.Write("The " + command.Noun + " cannot be taken.");
        }
        else
        {
            Inventory.Add(item);
            currentLocation.RemoveItem(item);
            IO.Write("You take the " + command.Noun + ".");
        }
    }
}