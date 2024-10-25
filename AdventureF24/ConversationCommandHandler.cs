namespace AdventureF24;

public class ConversationCommandHandler : ICommandHandler
{
    private static Dictionary<string, Action<Command>> commandMap =
        new Dictionary<string, Action<Command>>()
        {
            {"y", Yes},
            {"n", No},
            {"leave", Leave},
        };
    
    private static BaseCommandHandler baseHandler =
        new BaseCommandHandler(commandMap);
    
    public void Handle(Command command)
    {
        baseHandler.Handle(command);
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
        Debugger.Write("Handling leave command");
    }
}