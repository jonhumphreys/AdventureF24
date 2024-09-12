namespace AdventureF24;

public static class Game
{
    private static bool isPlaying = true;
    
    public static void Play()
    {
        while (isPlaying)
        {
            CommandProcessor.GetCommand();
            
            /*
            
            
            if (words.Length > 2)
                Console.WriteLine("Too Many Words");
            
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            
            if (input == "exit")
            {
                isPlaying = false;
            }
            */
        }
    }
}