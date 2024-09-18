namespace AdventureF24;

public class Command
{
    public string Verb;
    public string Noun;
    public bool IsValid = false;

    public string ToString()
    {
        return "Command: Verb = [" + Verb + "], Noun = [" + Noun + "], IsValid = " + IsValid;
    }
}