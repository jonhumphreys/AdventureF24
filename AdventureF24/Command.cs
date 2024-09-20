namespace AdventureF24;

public class Command
{
    public string Verb = String.Empty;
    public string Noun = String.Empty;
    public bool IsValid = false;

    public bool HasNoNoun()
    {
        if (Noun == String.Empty)
            return true;
        return false;
    }
    
    public string ToString()
    {
        return "Command: Verb = [" + Verb + "], Noun = [" + Noun + "], IsValid = " + IsValid;
    }
}