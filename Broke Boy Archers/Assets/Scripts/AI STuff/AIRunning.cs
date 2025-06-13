using Pathfinding;
using UnityEngine;

public class AIRunning : AIState
{
    
    public override void EnterState(Bot stateManager, AIPath ai)
    {
        Debug.Log("AI Running");
    }

    public override void UpdateState(Bot bot, AIPath ai)
    {
        //The A* package has a function to create a path that goes the opposite direction of an object
        if (Shoot.currentArrowHolder && Vector2.Distance(bot.transform.position, Shoot.currentArrowHolder.transform.position) < 3f)
        {
            var fleePath = FleePath.Construct(bot.transform.position, Shoot.currentArrowHolder.transform.position, 20000);
            ai.SetPath(fleePath);
        }
        
        //If no one has the arrow
        if (!Shoot.currentArrowHolder)
        {
            bot.SwitchState(bot.RetrievingState);
        }
        
    }
    
    
}
