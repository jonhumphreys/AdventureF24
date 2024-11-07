namespace AdventureF24;

public static class Game
{
    private static bool isPlaying = true;
    
    public static void Play()
    {
        Initialize();
        
        while (isPlaying)
        {
            Command command = CommandProcessor.GetCommand();
            if (command.IsValid)
            {
                Debugger.Write(command.ToString());
                CommandHandler.Handle(command);
            }
        }
    }

    private static void Initialize()
    {
        Map.Initialize();
        Player.Initialize();
        States.Initialize();
        States.ChangeState(StateType.Snoozing);
    }
}