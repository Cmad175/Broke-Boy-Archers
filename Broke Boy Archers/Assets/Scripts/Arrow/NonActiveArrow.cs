using UnityEngine;

public class NonActiveArrow : MonoBehaviour
{
    //This is here for the Bot AI scripts
    public static NonActiveArrow nonActiveArrow;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        nonActiveArrow = this;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            _audioSource.Play();
            nonActiveArrow = null;
            Destroy(gameObject);
        }
    }
}
