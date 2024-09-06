namespace AdventureF24;

public static class Game
{
    private static bool isPlaying = true;
    
    public static void Play()
    {
        while (isPlaying)
        {
            Console.WriteLine("> ");
            string input = Console.ReadLine();
            Console.WriteLine("Input was: " + input);

            if (input == "exit")
            {
                isPlaying = false;
            }
        }
    }
}