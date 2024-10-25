namespace AdventureF24;

public class ExplorationCommandHandler : ICommandHandler
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
            {"inventory", Inventory},
        };

    private static BaseCommandHandler baseHandler =
        new BaseCommandHandler(commandMap);
    
    public void Handle(Command command)
    {
        baseHandler.Handle(command);
    }
    
    private static void Inventory(Command command)
    {
        Player.ShowInventory();
    }

    private static void Drop(Command command)
    {
        Player.Drop(command);
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