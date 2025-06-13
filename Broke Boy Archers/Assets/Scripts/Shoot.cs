using UnityEngine;

public class Shoot: MonoBehaviour
{
    //this bool is mainly here for bot stuff
    public static Shoot currentArrowHolder;

    [SerializeField] private GameObject activeArrowPrefab;
    [SerializeField] private AudioClip clip;
    private AudioSource audioSource;
    private UpdateSprites _updateSprites;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        _updateSprites = GetComponentInChildren<UpdateSprites>();
    }
    
    public void StartShoot(Vector3 aimDirection)
    {
        if (currentArrowHolder != this)
            return;
        
        _updateSprites.SwitchToWalkingSprite();
        audioSource.PlayOneShot(clip);
        
        //The Player/AIAttacking scripts do the shoot action and pass through the angle they are looking
        //Get the position around the player using Cos and Sin
        var directionPos = new Vector3(Mathf.Cos(aimDirection.z * Mathf.Deg2Rad), Mathf.Sin(aimDirection.z * Mathf.Deg2Rad));
        Instantiate(activeArrowPrefab, transform.position + directionPos * 4,Quaternion.Euler(0,0,aimDirection.z));
        currentArrowHolder = null;
    }

    private void PickUpArrow()
    {
        currentArrowHolder = this;
        _updateSprites.SwitchToCrossbowSprite();   
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("NonActiveArrow"))
        {
            PickUpArrow();
        }
    }

}