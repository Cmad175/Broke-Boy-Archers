using Pathfinding;
using UnityEngine;

public class AIRetrieving : AIState
{
    private Shoot _shoot;
    
    public override void EnterState(Bot stateManager, AIPath ai)
    {
        Debug.Log("AI Retrieving");
        _shoot = stateManager.shoot;
    }

    public override void UpdateState(Bot bot, AIPath ai)
    {
        //Moves towards the nonActiveArrow
        if (NonActiveArrow.nonActiveArrow)
        {
            var path = ABPath.Construct(bot.transform.position, NonActiveArrow.nonActiveArrow.transform.position);
            ai.SetPath(path);
        }
        
        //This is when the non active arrow gets picked up and depending if the bot has it or not enters the appropriate state
        if (!Shoot.currentArrowHolder) return;
        
        if(Shoot.currentArrowHolder == _shoot)
            bot.SwitchState(bot.AttackingState);
        else
            bot.SwitchState(bot.RunningState);

    }
    
}


