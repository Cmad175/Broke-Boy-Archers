using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //So the quirky thing about this script is that the in the Obstacle Scriptable object is a list of sprites.
    //The sprites are ordered so that the list position of the sprite correlates to the health it represents
    
    [SerializeField] ObstacleSO obstacleSo;
    
    private SpriteRenderer spriteRenderer;
    private Collider2D _collider2D;
    private Rigidbody2D _rigidbody2D;
    private int health;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        health = obstacleSo.health;
        spriteRenderer.sprite = obstacleSo.sprites[health];
        _rigidbody2D.mass = obstacleSo.mass;
    }
    
    private void TakeDamage(int damage)
    {
        health -= damage;
        
        spriteRenderer.sprite = obstacleSo.sprites[health];
        
        if (health <= 0)
        {
            _collider2D.enabled = false;
            _rigidbody2D.simulated = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ActiveArrow"))
        {
            TakeDamage(1);
        }
    }
}
