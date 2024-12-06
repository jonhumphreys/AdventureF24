namespace AdventureF24;

public static class Conditions
{
    private static Dictionary<ConditionType, Condition> conditions = 
        new Dictionary<ConditionType, Condition>();

    public static void Initialize()
    {
        Condition isDrunked = new Condition(ConditionType.IsDrunk);
        isDrunked.AddToActivateCallList(ConditionActions.WriteOutput("Hic!"));
        isDrunked.AddToActivateCallList(
            ConditionActions.AddMapConnection(
                "Entrance Hall", "west", 
                "Treasure Room"));
        isDrunked.AddToActivateCallList(
            ConditionActions.RemoveMapConnection(
                "Entrance Hall", "north"));
        isDrunked.AddToActivateCallList(ConditionActions.MovePlayerToLocation("Hole"));
        AddCondition(isDrunked);

        Condition hasKey = new Condition(ConditionType.HasKey);
        hasKey.AddToActivateCallList(ConditionActions.WriteOutput("Now that you have the key, you can go east."));
        AddCondition(hasKey);

        Condition wonGame = new Condition(ConditionType.WonGame);
        wonGame.AddToActivateCallList(ConditionActions.WinGame());
        AddCondition(wonGame);
        
        // to make a new condition:
        // 1: Go to the ConditionTypes.cs file and add it (like isTiny)
        // 2: Create a new condition like this:
        Condition isTiny = new Condition(ConditionType.IsTiny);
        // 3: Add any things you want to happen when the condition is true
        // like this -> isTiny.AddToActivateCallList();
        // examples:
        // To print some message: ConditionActions.WriteOutput
        isTiny.AddToActivateCallList(ConditionActions.WriteOutput("You shrink down to mouse size!"));
        
        // To add a connection on the map: ConditionActions.AddMapConnection
        isTiny.AddToActivateCallList(ConditionActions.AddMapConnection("Entrance Hall", "west", "Mouse Hole"));
        
        // To delete a conenction on the map: ConditionActions.RemoveMapConnection
        //isTiny.AddToActivateCallList(ConditionActions.RemoveMapConnection("Entrance Hall", "down"));
        
        // To teleport player: ConditionActions.MovePlayerToLocation
        //isTiny.AddToActivateCallList(ConditionActions.MovePlayerToLocation("Entrance Hall"));
        
        // To add an item to the player's inventory: ConditionActions.AddItemToInventory
        isTiny.AddToActivateCallList(ConditionActions.AddItemToInventory(ItemType.crumbs));
        
        // To remove an item from the player's inventory: ConditionActions.RemoveItemFromInventory
        //isTiny.AddToActivateCallList(ConditionActions.RemoveItemFromInventory(ItemType.beer));
        
        // To add item to a location: ConditionActions.AddItemToLocation
        //isTiny.AddToActivateCallList(ConditionActions.AddItemToLocation(ItemType.beer, "Entrance Hall"));
        
        // To remove item from a location: ConditionActions.RemoveItemFromLocation
        //isTiny.AddToActivateCallList(ConditionActions.RemoveItemFromLocation(ItemType.beer, "Entrance Hall"));
        AddCondition(isTiny);
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