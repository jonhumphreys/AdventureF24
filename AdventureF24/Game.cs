namespace AdventureF24;

public static class Game
{
    private static bool isPlaying = true;
    
    public static void Play()
    {
        Debugger.Tron();
        
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