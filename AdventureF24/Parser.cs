namespace AdventureF24;

public static class Parser
{
    public static void Parse(string input)
    {
        // remove extra whitespace
        input = RemoveWhitespace(input);
        
        // convert to lower case
        input = input.ToLower();
        
        // split on space
        string[] words = input.Split(' ');
        
        // check number of words
        
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