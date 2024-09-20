namespace AdventureF24;

public static class CommandValidator
{
    
    public static Command Validate(Command command)
    {
        if (Vocabulary.IsVerb(command.Verb))
        {
            Debugger.Write("Valid verb");
            if (Vocabulary.IsStandaloneVerb(command.Verb))
            {
                Debugger.Write("Standalone verb");
                if (command.HasNoNoun())
                {
                    Debugger.Write("Has no noun");
                    command.IsValid = true;
                }
            }
            else if (Vocabulary.IsNoun(command.Noun))
            {
                Debugger.Write("Valid noun");
                command.IsValid = true;
            }
        }

        return command;
    }
}