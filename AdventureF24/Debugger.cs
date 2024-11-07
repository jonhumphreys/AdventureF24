namespace AdventureF24;

public static class Debugger
{
    private static bool isActive = false;
    
    public static void Write(string message)
    {
        if (isActive)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            IO.WriteLine(message);
            Console.ResetColor();
        }
    }

    public static void Tron()
    {
        isActive = true;
        IO.WriteLine("Debugging Enabled");
    }
    
    public static void Troff()
    {
        isActive = false;
        IO.WriteLine("Debugging Disabled");
    }
}