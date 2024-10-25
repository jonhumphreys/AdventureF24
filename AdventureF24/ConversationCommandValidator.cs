namespace AdventureF24;

public class ConversationCommandValidator  : ICommandValidator
{
    public Command Validate(Command command)
    {
        if (command.Verb == "y" || command.Verb == "n" || command.Verb == "leave")
        {
            command.IsValid = true;
            return command;
        }
        return new Command();
    }
}