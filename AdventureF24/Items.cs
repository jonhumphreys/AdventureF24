using System.Text.Json;

namespace AdventureF24;

public static class Items
{
    private static Dictionary<ItemType, Item> nametoItem = new Dictionary<ItemType, Item>();
    
    public static void Initialize()
    {
        //read the json file text
        string path = Path.Combine(Environment.CurrentDirectory, "Items.json");
        string rawText = File.ReadAllText(path);
        //convert the text to ItemsJsonData
        ItemsJsonData? data = JsonSerializer.Deserialize<ItemsJsonData>(rawText);
        
        //convert all the items
        foreach (ItemJsonData itemData in data.Items)
        {
            if (!Enum.TryParse(itemData.ItemType,
                    true, out ItemType itemType))
            {
                IO.Error("invalid item type: " + itemData.ItemType + " in Items.json");
                continue;
            }

            Item? item = CreateItem(itemType, itemData.Description, 
                itemData.InitialLocationText, itemData.IsTakeable);
            if (item != null)
            {
                Map.AddItem(itemType, itemData.Location);
            }
        }
        
    }

    public static Item? CreateItem(ItemType itemType, string description, string initialLocationDescription, bool isTakeable = true)
    {
        if (nametoItem.ContainsKey(itemType))
        {
            IO.Error("Item " + itemType.ToString() + " already exists");
            return null;
        }
        Item item = new Item(itemType, description, initialLocationDescription, isTakeable);
        nametoItem.Add(itemType, item);
        return item;
    }

    public static Item? FindItem(ItemType itemType)
    {
        if (nametoItem.ContainsKey(itemType))
        {
            return nametoItem[itemType];
        }

        return null;
    }
}