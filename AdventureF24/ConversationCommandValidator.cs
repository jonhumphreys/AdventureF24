namespace AdventureF24;

public static class ConversationCommandValidator
{
    public static Command Validate(Command command)
    {
        if (command.Verb == "y" || command.Verb == "n" || command.Verb == "leave")
        {
            command.IsValid = true;
            return command;
        }
        return new Command();
    }
}