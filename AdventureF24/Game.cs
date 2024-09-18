namespace AdventureF24;

public static class Game
{
    private static bool isPlaying = true;
    
    public static void Play()
    {
        while (isPlaying)
        {
            Command command = CommandProcessor.GetCommand();
            if (command.IsValid)
            {
                IO.Write(command.ToString());
            }
            else
            {
                IO.Write("Invalid Command");
            }
        }
    }
}