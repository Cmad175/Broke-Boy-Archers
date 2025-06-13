using Pathfinding;

public abstract class AIState
{
    public abstract void EnterState(Bot stateManager, AIPath ai);

    public abstract void UpdateState(Bot bot, AIPath ai);

}
