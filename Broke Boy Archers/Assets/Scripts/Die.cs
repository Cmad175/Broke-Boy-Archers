using UnityEngine;

public class Die : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ActiveArrow"))
        {
            audioSource.PlayOneShot(clip);
            gameObject.SetActive(false);
            GameManager.instance.RemovePlayer(gameObject.name);
        }
    }
}
