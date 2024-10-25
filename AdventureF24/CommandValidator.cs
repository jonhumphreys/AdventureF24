using System.Windows.Input;

namespace AdventureF24;

public static class CommandValidator
{
    private static Dictionary<StateType, ICommandValidator> validators =
        new Dictionary<StateType, ICommandValidator>()
        {
            { StateType.Exploring, new ExplorationCommandValidator()},
            { StateType.Conversation, new ConversationCommandValidator() }
        };
    
    public static Command Validate(Command command)
    {
        if (validators.ContainsKey(States.GetCurrentState()))
        {
            ICommandValidator validator = validators[States.GetCurrentState()];
            return validator.Validate(command);
        }
        return new Command();
    }
}