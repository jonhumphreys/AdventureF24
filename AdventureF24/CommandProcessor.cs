namespace AdventureF24;

public static class CommandProcessor
{
    public static Command GetCommand()
    {
        string input = IO.Read();
        Command command = Parser.Parse(input);
        command = CommandValidator.Validate(command);

        return command;
    }
}