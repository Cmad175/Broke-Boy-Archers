using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public AIAttacking AttackingState;
    public AIRunning RunningState;
    public AIRetrieving RetrievingState;
    
    public Shoot shoot { get; private set; }
    
    private AIState _currentAIState;
    private AIPath _ai;
    private UpdateSprites _updateSprites;
    private SpriteRenderer _visual;
    
    private void Awake()
    {
        AttackingState = new AIAttacking();
        RunningState = new AIRunning();
        RetrievingState = new AIRetrieving();

        _ai = this.AddComponent<AIPath>();
        _ai.height = 1;
        _ai.maxSpeed = 15;
        _ai.gravity = Vector3.zero;
        _ai.orientation = OrientationMode.YAxisForward;
        
        _updateSprites = GetComponent<UpdateSprites>();
        shoot = GetComponent<Shoot>();
        
        //Rotates the visual because the AI agent has up as 0 instead of right
        _visual = GetComponentInChildren<SpriteRenderer>();
        _visual.transform.rotation = Quaternion.Euler(0, 0, 90f);
    }

    public void SetUpBot(CharacterSO characterSo)
    {
        _updateSprites.AddSpritesSo(characterSo);
    }
    
    private void Start()
    {
        _currentAIState = RetrievingState;
        _currentAIState.EnterState(this, _ai);
    }
    
    private void Update() => _currentAIState.UpdateState(this, _ai);

    public void SwitchState(AIState newState)
    {
        _currentAIState = newState;
        _currentAIState.EnterState(this, _ai);
    }

    
}
