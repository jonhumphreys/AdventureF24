namespace AdventureF24;

public static class Parser
{
    public static Command Parse(string input)
    {
        Command command = new Command();

        input = RemoveWhitespace(input);
        input = input.ToLower();
        
        string[] words = input.Split(' ');
        
        // check number of words
        if (words.Length == 2)
        {
            command.Verb = words[0];
            command.Noun = words[1];
        }

        if (words.Length == 1)
        {
            command.Verb = words[0];
        }

        return command;
    }

    public static string RemoveWhitespace(string input)
    {
        input = input.Trim();
        
        while (input.Contains("  "))
        {
            input = input.Replace("  ", " ");
        }
        
        return input;
    }
}