namespace AdventureF24;

public class BaseCommandHandler
{
    private Dictionary<string, Action<Command>> commandMap;

    public BaseCommandHandler(Dictionary<string, Action<Command>> commandMapInput)
    {
        commandMap = commandMapInput;
    }
    
    public void Handle(Command command)
    {
        if (commandMap.ContainsKey(command.Verb))
        {
            Action<Command> action = commandMap[command.Verb];
            action.Invoke(command);
        }
        else
        {
            IO.Write("I don't know how to do that.");
        }
    }
}