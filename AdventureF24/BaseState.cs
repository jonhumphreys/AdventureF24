namespace AdventureF24;

public class BaseState
{
    public bool IsActive { get; private set; }

    private List<Action> methodsToCallOnActivate = new List<Action>();
    private List<Action> methodsToCallOnDeactivate = new List<Action>();
    
    public BaseState()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
        foreach (Action action in methodsToCallOnActivate)
        {
            action.Invoke();
        }
    }

    public void Deactivate()
    {
        IsActive = false;
        foreach (Action action in methodsToCallOnDeactivate)
        {
            action.Invoke();
        }
    }

    public void AddToActivateCallList(Action action)
    {
        methodsToCallOnActivate.Add(action);
    }
    
    public void AddToDeactivateCallList(Action action)
    {
        methodsToCallOnDeactivate.Add(action);
    }
}