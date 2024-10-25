namespace AdventureF24;

public static class States
{
    private static State currentState;
    private static Dictionary<StateType, State> states = 
        new Dictionary<StateType, State>();

    public static void Initialize()
    {
        AddState(StateType.Exploring);
        AddState(StateType.Combat);
        AddState(StateType.Conversation);
        
        currentState = states[StateType.Exploring];
    }

    public static StateType GetCurrentState()
    {
        return currentState.Type;
    }

    public static void AddState(StateType type)
    {
        State state = new State(type);
        if (!states.ContainsKey(state.Type))
            states[state.Type] = state;
    }

    public static void ChangeState(StateType type)  
    {   
        if (!states.ContainsKey(type))
        {
            IO.Error($"No state of type {type} was found.");
            return;
        }
        
        currentState.Deactivate();
        currentState = states[type];
        currentState.Activate();
    }
}