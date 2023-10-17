using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip walkSoundClip;

    [SerializeField]
    private AudioClip jumpSoundClip;

    private float volume = 1f;

    [SerializeField]
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void playSoundEffect(AudioClip soundEffectClip, Vector2 position, float volume)
    {
        AudioSource.PlayClipAtPoint(soundEffectClip, position, volume);
    }

    public void playWalkSound()
    {
        if (audioSource.isPlaying)
            {

            }
            else
            {
                audioSource.clip = walkSoundClip;
                audioSource.volume = volume;
                audioSource.Play();
            }     
    }

    public void plaJumpSound()
    {
        if (audioSource.isPlaying)
        {

        }
        else
        {
            audioSource.clip = jumpSoundClip;
            audioSource.volume = volume;
            audioSource.Play();
        }
    }
}
