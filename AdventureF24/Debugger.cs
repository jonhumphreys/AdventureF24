namespace AdventureF24;

public static class Debugger
{
    private static bool isActive = false;
    
    public static void Write(string message)
    {
        if (isActive)
        {
            IO.Write(message);
        }
    }

    public static void Tron()
    {
        isActive = true;
        IO.Write("Debugging Enabled");
    }
    
    public static void Troff()
    {
        isActive = false;
        IO.Write("Debugging Disabled");
    }
}