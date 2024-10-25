using System.Net.Mime;

namespace AdventureF24;

public static class IO
{
    public static void Write(string output)
    {
        Console.WriteLine(output);
    }
    
    public static string Read()
    {
        Console.Write("> ");
        return Console.ReadLine();
    }

    public static void Error(string output)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Write("ERROR: " + output);
        Console.ResetColor();
    }
}