namespace AdventureF24;

public static class CommandHandler
{
    private static Dictionary<string, Action<Command>> commandMap =
        new Dictionary<string, Action<Command>>()
        {
            {"go", Move},
            {"take", Take},
            {"tron", Tron},
            {"troff", Troff},
            {"look", Look},
            {"drop", Drop},
        };

    private static void Drop(Command command)
    {
        Player.Drop(command);
    }

    public static void Handle(Command command)
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

    private static void Look(Command command)
    {
        IO.Write(Player.GetLocationDescription());
    }

    private static void Move(Command command)
    {
        Player.Move(command);
    }
    
    private static void Take(Command command)
    {
        Player.Take(command);
    }
    
    private static void Tron(Command command)
    {
        Debugger.Tron();
    }
    
    private static void Troff(Command command)
    {
        Debugger.Troff();
    }
}