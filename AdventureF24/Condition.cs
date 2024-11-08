namespace AdventureF24;

public class Condition : BaseState
{
    public ConditionType Type;

    public Condition(ConditionType conditionType) : base()
    {
        Type = conditionType;
    }
}