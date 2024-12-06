using System.Diagnostics;

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
                if (command.Verb == "exit")
                    isPlaying = false;
            }
        }
    }

    private static void Initialize()
    {
        Map.Initialize();
        Items.Initialize();
        Player.Initialize();
        States.Initialize();
        Conditions.Initialize();
    }

    public static void WinGame()
    {
        IO.WriteLine("You won the game mo fo.");
        isPlaying = false;
    }
    
}