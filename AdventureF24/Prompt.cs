namespace AdventureF24;

public static class Prompt
{
    public static void Show()
    {
        switch (States.GetCurrentState())
        {
            case StateType.Exploring:
                IO.Write("> ");
                break;
            case StateType.Conversation:
                IO.WriteLine("(y, n, leave)");
                IO.Write("% ");
                break;
            default:
                IO.Write("> ");
                break;
        }
    }
}