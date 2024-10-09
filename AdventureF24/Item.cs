namespace AdventureF24;

public class Item
{
    public string Name;
    // function
    public string Description;
    public string InitialLocationDescription;
    
    public int UseCount;
    // expiration
    public bool IsTakeable;
    public bool IsEdible;
    public bool HasBeenPickedUp = false;

    public Item(string name, string description, string initialLocationDescription, bool isTakeable = true)
    {
        Name = name;
        Description = description;
        InitialLocationDescription = initialLocationDescription;
        IsTakeable = isTakeable;
        Vocabulary.AddNoun(name);
    }

    public void Pickup()
    {
        HasBeenPickedUp = true;
    }

    public string GetLocationDescription()
    {
        if (HasBeenPickedUp)
            return Description;
        else
            return InitialLocationDescription;
    }
}