using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
     [SerializeField]
    private AudioClip[] musicClips;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void playMusic(AudioClip audioClip,Vector2 position,float volume)
    {
        AudioSource.PlayClipAtPoint(audioClip,position,volume);
    }

    private void playMusic(AudioClip[] audioClip, Vector2 position, float volume)
    {
        AudioSource.PlayClipAtPoint(musicClips[Random.Range(0,musicClips.Length)], position, volume);
    }

    private void Update()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.clip = musicClips[Random.Range(0, musicClips.Length)];
            audioSource.Play();
        }
        

    }
}
