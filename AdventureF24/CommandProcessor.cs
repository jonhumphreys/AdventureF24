namespace AdventureF24;

public static class CommandProcessor
{
    public static Command GetCommand()
    {
        string input = IO.Read();
        
        Debugger.Write("Raw Input: [" + input + "]");
        
        Command command = Parser.Parse(input);
        
        Debugger.Write("After parsing: Verb = [" + command.Verb + 
                       "], Noun = [" + command.Noun + "]");
        
        command = CommandValidator.Validate(command);

        return command;
    }
}