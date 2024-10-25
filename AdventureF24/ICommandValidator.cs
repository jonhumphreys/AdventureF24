namespace AdventureF24;

public interface ICommandValidator
{
    Command Validate(Command command);
}