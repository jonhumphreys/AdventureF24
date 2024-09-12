namespace AdventureF24;

public static class CommandProcessor
{
    public static void GetCommand()
    {
        // get the raw input string
        Console.WriteLine("> ");
        string input = Console.ReadLine();
        Console.WriteLine("Input was: " + input);
        
        // parse out command
        Parser.Parse(input);
        
        // validate command
    }
}