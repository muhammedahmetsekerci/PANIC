using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsScreen;
    public GameObject creditsScreen;

    public AudioSource audioSource;
    public AudioClip audioClip;
    bool muteSound = false;
    // Start is called before the first frame update
    public void Start()
    {
        settingsScreen.SetActive(false);
        creditsScreen.SetActive(false);

        playSound();
    }
    public void playGame()
    {
        SceneManager.LoadScene("giris1");
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void openSettingsPanel()
    {
        settingsScreen.SetActive(true);
    }
    public void openCreditsPanel()
    {
        creditsScreen.SetActive(true);
    }
    private void playSound()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    public void mute()
    {
        muteSound = !muteSound;
        if (muteSound )
        {
            audioSource.volume = 0f;
        }
        else
        {
            audioSource.volume = 1f;
        }
    }

}
