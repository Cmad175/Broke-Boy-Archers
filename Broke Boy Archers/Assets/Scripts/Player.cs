using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputAction _movementAction;
    private InputAction _shootAction;
    private Rigidbody2D _rigidbody2D;
    private UpdateSprites _updateSprites;
    private Shoot _shoot;
    
    private float _moveSpeed = 700f;
    
    //This is the entrance method that gets all of the Actions and components set up
    public void SetUpPlayer(CharacterSO so)
    {
        _movementAction = so.moveAction;
        _shootAction = so.shootAction;
        
        _movementAction.Enable();
        _shootAction.Enable();
        
        _shootAction.performed += UpdateShoot;
        
        name = so.characterName;
        _shoot = GetComponent<Shoot>();
        _updateSprites = GetComponent<UpdateSprites>();
        _updateSprites.AddSpritesSo(so);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    

    private void OnDisable()
    {
        _shootAction.performed -= UpdateShoot;
    }
    
    private void UpdateShoot(InputAction.CallbackContext ctx) => _shoot.StartShoot(transform.eulerAngles);
    private void FixedUpdate() => _rigidbody2D.linearVelocity = _movementAction.ReadValue<Vector2>() * (_moveSpeed * Time.deltaTime);
    
    private void Update()
    {
        //Rotates the player
        var angle = Mathf.Atan2(_rigidbody2D.linearVelocity.y,_rigidbody2D.linearVelocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
    
}