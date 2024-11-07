namespace AdventureF24;

public static class CommandValidator
{
    public static Command Validate(Command command)
    {
        switch (States.GetCurrentState())
        {
            case StateType.Exploring:
                return ExplorationCommandValidator.Validate(command);
                break;
            case StateType.Conversation:
                return ConversationCommandValidator.Validate(command);
                break;
        }
        return new Command();
    }
}