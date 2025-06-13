using UnityEngine;

public class ActiveArrow : MonoBehaviour
{   
    //This is the arrow that characters shoot
    //The other gameobjects have the tags and components that actually do the damaging stuff on Obstacle and Die
    //When it hits anything it spawns the NonActiveArrow that can get picked up.
    [SerializeField] private GameObject nonActiveArrowPrefab;
    [SerializeField] private float _arrowSpeed = 1000f;

    private Rigidbody2D _rigidbody2D;

    private void Awake() => _rigidbody2D = GetComponent<Rigidbody2D>();

    private void OnEnable()
    {
        _rigidbody2D.linearVelocity = transform.right * _arrowSpeed;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(nonActiveArrowPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
