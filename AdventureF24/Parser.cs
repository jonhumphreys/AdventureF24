namespace AdventureF24;

public static class Parser
{
    public static Command Parse(string input)
    {
        Command command = new Command();

        input = RemoveWhitespace(input);
        
        Debugger.Write("After removing whitespace: [" + input + "]");
        
        input = input.ToLower();
        
        Debugger.Write("After converting to lowercase: [" + input + "]");
        
        string[] words = input.Split(' ');
        
        Debugger.Write("Split into " + words.Length + " words");
        
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