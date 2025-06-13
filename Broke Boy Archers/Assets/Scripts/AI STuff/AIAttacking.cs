using System.Linq;
using Pathfinding;
using UnityEngine;

public class AIAttacking : AIState
{
    private Shoot _shoot;
    private float _shootTimerLimit;
    private float _shootCounter;
    private bool _hasShootStarted;
    GameObject[] _characters;
    GameObject _closestCharacter;
    float _closestDistance = Mathf.Infinity;
    
    public override void EnterState(Bot stateManager, AIPath ai)
    {
        Debug.Log("AI Attack");
        _shoot = stateManager.shoot;
        _shootTimerLimit = 0;
        _shootCounter = 0;
        _hasShootStarted = false;
        
        _characters = GameObject.FindGameObjectsWithTag("Character");
        _characters = _characters.Where(p => p != ai.gameObject).ToArray();//removes its self from the array
    }

    public override void UpdateState(Bot bot, AIPath ai)
    {
        //Searches for the closet player
        foreach (var character in _characters)
        {
            float distance = Vector2.Distance(bot.transform.position, character.transform.position);
            if (distance < _closestDistance)
            {
                _closestDistance = distance;
                _closestCharacter = character;
            }
        }
        
        //moves towards the closest player
        if (_closestCharacter && _closestDistance > 1f)
        {
            var path = ABPath.Construct(bot.transform.position, _closestCharacter.transform.position);
            ai.SetPath(path);
        }
        
        //Im doing this whole countdown thing just to add some variance to the bot's shooting
        
        //raycasts the direction the bot is facing
        if (!_hasShootStarted)
        {
            RaycastHit2D hit = Physics2D.Raycast(bot.transform.position + (ai.velocity.normalized * 3), ai.velocity.normalized, Mathf.Infinity);
            if (hit.collider && hit.collider.CompareTag("Character") && !_hasShootStarted)
            {
                //If raycast hits a Character starts the shoot countdown
                Debug.Log(hit.collider.name);
                _hasShootStarted = true;
                _shootTimerLimit = Random.Range(0.2f, 0.5f);
                _shootCounter = 0f;
            }
        }
        
        //The shoot countdown. When the countdown is finished it shoots
        if (_hasShootStarted)
        {
            _shootCounter += Time.deltaTime;
            if (_shootCounter >= _shootTimerLimit)
            {
                //Doing this wonky rotation stuff because up is 0 instead of right 
                _shoot.StartShoot(new Vector3(0f,0f,(ai.transform.eulerAngles.z + 90f + 360f) % 360f));
                _hasShootStarted = false;
                bot.SwitchState(bot.RetrievingState);
            }
        }
    }
    
    
}
