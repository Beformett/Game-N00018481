using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip hurtSound;
    public AudioClip attackSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayHurtSound()
    {
        audioSource.PlayOneShot(hurtSound);
    }

    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackSound);
    }
}
