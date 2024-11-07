namespace AdventureF24;

public static class ConversationCommandHandler
{
    private static Dictionary<string, Action<Command>> commandMap =
        new Dictionary<string, Action<Command>>()
        {
            {"y", Yes},
            {"n", No},
            {"leave", Leave},
        };
    
    public static void Handle(Command command)
    {
        if (commandMap.ContainsKey(command.Verb))
        {
            Action<Command> action = commandMap[command.Verb];
            action.Invoke(command);
        }
        else
        {
            IO.WriteLine("I don't understand that command.");
        }
    }

    private static void Yes(Command command)
    {
        Debugger.Write("Handling yes command");
    }
    
    private static void No(Command command)
    {
        Debugger.Write("Handling no command");
    }
    
    private static void Leave(Command command)
    {
        Debugger.Write("Trying to switch to exploration state");
        States.ChangeState(StateType.Exploring);
    }
}