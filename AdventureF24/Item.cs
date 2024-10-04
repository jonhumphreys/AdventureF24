namespace AdventureF24;

public class Item
{
    public string Name;
    // function
    public string Description;
    public string LocationDescription;
    
    public int UseCount;
    // expiration
    public bool IsTakeable;
    public bool IsEdible;

    public Item(string name, string description, string locationDescription, bool isTakeable = true)
    {
        Name = name;
        Description = description;
        LocationDescription = locationDescription;
        IsTakeable = isTakeable;
        Vocabulary.AddNoun(name);
    }
}