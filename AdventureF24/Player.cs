using System.Data;

namespace AdventureF24;

public static class Player
{
    private static Location currentLocation;
    public static List<Item> Inventory = new List<Item>();

    public static void Initialize()
    {
        currentLocation = Map.StartLocation;
        IO.WriteLine(currentLocation.GetDescription());
    }
    
    public static void Move(Command command)
    {
        if (currentLocation.CanMoveInDirection(command.Noun))
        {
            if (currentLocation.Name == "Entrance Hall" && command.Noun == "east"
                                                        && Conditions.IsFalse(ConditionType.HasKey))
            {
                IO.WriteLine("You need the key to go there.");
                return;
            }
            
            currentLocation = currentLocation.GetLocationInDirection(command.Noun);
            IO.WriteLine(currentLocation.GetDescription());

            if (currentLocation.Name == "Mouse Hole")
            {
                Conditions.ChangeCondition(ConditionType.WonGame, true);
            }
        }
        else
        {
            IO.WriteLine("Can't go that way.");
        }
    }

    public static void Take(Command command)
    {
        Item item = currentLocation.FindItem(command.Noun);

        if (item == null)
        {
            IO.WriteLine("There is no " + command.Noun + " here.");
        }
        else if (!item.IsTakeable)
        {
            IO.WriteLine("The " + command.Noun + " cannot be taken.");
        }
        else
        {
            Inventory.Add(item);
            item.Pickup();
            currentLocation.RemoveItem(item);
            IO.WriteLine("You take the " + command.Noun + ".");

            if (item.Name == "key")
            {
                Conditions.ChangeCondition(ConditionType.HasKey, true);
            }
        }
    }

    public static string GetLocationDescription()
    {
        return currentLocation.GetDescription();
    }

    public static void Drop(Command command)
    {
        // find the item in inventory: lambda
        Item? item = Inventory.FirstOrDefault(i => 
            i.Name.ToLower() == command.Noun.ToLower());
        
        // if exists
        if (item != null)
        {
            Inventory.Remove(item);
            currentLocation.DropItem(item);
            IO.WriteLine($"You drop the {item.Name}.");

            if (item.Name == "key")
            {
                Conditions.ChangeCondition(ConditionType.HasKey, false);
            }
        }
    }

    public static void ShowInventory()
    {
        if (Inventory.Count == 0)
        {
            IO.WriteLine("You are empty-handed.");
        }
        else
        {
            IO.WriteLine("You are carrying:");
            foreach (Item item in Inventory)
            {
                string article = SemanticTools.CreateArticle(item.Name);
                IO.WriteLine("  " + article + " " + item.Name);
            }
        }
    }


    public static void Use(Command command)
    {
        if (command.Noun == "beer")
        {
            Conditions.ChangeCondition(ConditionType.IsDrunk, true);
        }
    }

    public static void MoveToLocation(string locationName)
    {
        Location? newLocation = Map.GetLocationByName(locationName);
        
        if (newLocation == null)
        {
            IO.WriteLine("There is no location named " + locationName + ".");
            return;
        }
        currentLocation = newLocation;
        IO.WriteLine(currentLocation.GetDescription());
    }

    public static void AddToInventory(ItemType itemType)
    {
        Item? item = Items.FindItem(itemType);
        if (item == null)
            return;
        Inventory.Add(item);
    }

    public static void RemoveItemFromInventory(ItemType itemType)
    {
        Item? item = Items.FindItem(itemType);
        if (item == null)
            return;
        Inventory.Remove(item);
    }

    public static void Eat(Command command)
    {
        if (command.Noun == "cake")
        {
            RemoveItemFromInventory(ItemType.cake);
            Conditions.ChangeCondition(ConditionType.IsTiny, true);
        }
    }
}