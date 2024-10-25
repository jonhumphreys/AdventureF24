namespace AdventureF24;

public interface ICommandHandler
{
    void Handle(Command command);
}