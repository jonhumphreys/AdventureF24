namespace AdventureF24;

public class Item
{
    public string Name { get; set; }
    
    // function
    public string Description { get; }
    public string InitialLocationDescription { get; }
    
    public int UseCount;
    // expiration
    public bool IsTakeable { get; }
    public bool IsEdible { get; }
    public bool HasBeenPickedUp { get; private set; } = false;

    public string LocationDescription
    {
        get
        {
            string article = SemanticTools.CreateArticle(Name);
            return $"There is {article} {Name} here.";
        }
    }
    
    public Item(string name, string description, string initialLocationDescription, 
        bool isTakeable = true)
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
            return LocationDescription;
        else
            return InitialLocationDescription;
    }
}