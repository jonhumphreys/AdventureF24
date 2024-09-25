namespace AdventureF24;

public static class Game
{
    private static bool isPlaying = true;
    
    public static void Play()
    {
        Debugger.Tron();
        
        Location location1 = new Location("Forest Clearning",
            "An opening in the forest, filled with wildflowers.");
        
        Location locationHallway = new Location("Hallway",
            "It;s a hallway");
        
        while (isPlaying)
        {
            Command command = CommandProcessor.GetCommand();
            if (command.IsValid)
            {
                IO.Write(command.ToString());

                if (command.Verb == "tron")
                {
                    Debugger.Tron();
                }
                else if (command.Verb == "troff")
                {
                    Debugger.Troff();
                }
            }
            else
            {
                IO.Write("Invalid Command");
            }
        }
    }
}