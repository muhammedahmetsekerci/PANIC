using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTrigger : MonoBehaviour
{
    public List<Button> buttons; // List of buttons to add hover detection to

    public List<Image> images; // List of buttons to add hover detection to
    public AudioSource audioSource;
    public AudioClip audioClip;

    bool muteSound = false;
    private void Start()
    {
        foreach (Button button in buttons)
        {
            // Add hover detection to each button in the list
            AddHoverDetectionToButton(button);
        }
        foreach(Image image in images)
        {
            image.enabled = false;
        }
    }

    private void AddHoverDetectionToButton(Button button)
    {
        // Add a pointer enter event using EventTrigger to the specified button
        EventTrigger trigger = button.gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            // If there's no EventTrigger, add one
            trigger = button.gameObject.AddComponent<EventTrigger>();
        }

        // Create an entry for the pointer enter event
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter; // Trigger on mouse hover

        // Add a callback to the entry
        entry.callback.AddListener((data) => { HandlePointerEnter(button); });

        // Add the entry to the EventTrigger
        trigger.triggers.Add(entry);
    }

    private void HandlePointerEnter(Button button)
    {
        // Print the button's name to the console
        Debug.Log("Button Hovered: " + button.gameObject.name);
        string name = button.gameObject.name;
        if (name == "start")
        {
            images[0].enabled = true;
            images[1].enabled = false;
            images[2].enabled = false;
            images[3].enabled = false;
            playSound();
        }
        else if (name == "settings")
        {
            images[0].enabled = false;
            images[1].enabled = true;
            images[2].enabled = false;
            images[3].enabled = false;
            playSound();
        }
        else if(name == "credits")
        {
            images[0].enabled = false;
            images[1].enabled = false;
            images[2].enabled = true;
            images[3].enabled = false;
            playSound();
        }
        else if( name == "quit")
        {
            images[0].enabled = false;
            images[1].enabled = false;
            images[2].enabled = false;
            images[3].enabled = true;
            playSound();
        }
    }
    private void playSound()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    private void setVisible(int index)
    {
        for(int i = 0; i < images.Count; i++)
        {
            if (i == index)
                images[i].enabled = true;
            images[i].enabled = false;
        }
    }
    public void mute()
    {
        muteSound = !muteSound;
        if (muteSound)
        {
            audioSource.volume = 0f;
        }
        else
        {
            audioSource.volume = 1f;
        }
    }
}
