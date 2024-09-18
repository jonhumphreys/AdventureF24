namespace AdventureF24;

public static class CommandValidator
{
    
    public static Command Validate(Command command)
    {
        if (Vocabulary.IsVerb(command.Verb))
        {
            if (Vocabulary.IsStandaloneVerb(command.Verb))
            {
                command.IsValid = true;
            }
            else if (Vocabulary.IsNoun(command.Noun))
            {
                command.IsValid = true;
            }
        }

        return command;
    }
}