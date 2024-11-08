namespace AdventureF24;

public static class Conditions
{
    private static Dictionary<ConditionType, Condition> conditions = 
        new Dictionary<ConditionType, Condition>();

    public static void Initialize()
    {
        Condition isDrunked = new Condition(ConditionType.IsDrunk);
        isDrunked.AddToActivateCallList(ConditionActions.WriteOutput("Hic!"));
        AddCondition(isDrunked);
    }

    public static void AddCondition(Condition condition)
    {
        conditions.Add(condition.Type, condition);
    }

    public static bool IsTrue(ConditionType conditionType)
    {
        if (NotInDictionary(conditionType))
            return false;
        return conditions[conditionType].IsActive;
    }

    public static bool IsFalse(ConditionType conditionType)
    {
        if (NotInDictionary(conditionType))
            return true;
        return !conditions[conditionType].IsActive;
    }
    
    public static void ChangeCondition(ConditionType conditionType,
        bool isSettingToTrue)
    {
        if (NotInDictionary(conditionType))
        {
            IO.Error("Condition " + conditionType + " is not valid.");
            return;
        }
        
        if (isSettingToTrue && IsFalse(conditionType))
        {
            conditions[conditionType].Activate();
        }
        else if (IsTrue(conditionType))
        {
            conditions[conditionType].Deactivate();
        }
    }

    private static bool NotInDictionary(ConditionType conditionType)
    {
        return !conditions.ContainsKey(conditionType);
    }
}