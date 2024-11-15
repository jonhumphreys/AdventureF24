namespace AdventureF24;

public static class Items
{
    private static Dictionary<ItemType, Item> nameToItem = new Dictionary<ItemType, Item>();

    public static void Initialize()
    {
        Item? key = CreateItem(ItemType.key,
            "An old, rusty, comically oversized key.",
            "There is a key poking out from the dust.");
        Map.AddItem(key, "Storage Room");

        Item? beer = CreateItem(ItemType.beer,
            "Beer's beer.",
            "There be beer here.");
        Map.AddItem(beer, "Storage Room");
    }
    
    public static Item? CreateItem(ItemType itemType, string description,
        string initialLocationDescription, bool isTakable = true) 
    {
        if (nameToItem.ContainsKey(itemType))
        {
            IO.Error($"Item {itemType.ToString()} already exists");
            return null;
        }
        Item item = new Item(itemType, description, initialLocationDescription, isTakable);
        nameToItem.Add(itemType, item);

        return item;
    }

    public static Item? FindItem(ItemType itemType)
    {
        if (nameToItem.ContainsKey(itemType))
            return nameToItem[itemType];
        return null;
    }
}