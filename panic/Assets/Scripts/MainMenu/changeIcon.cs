using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class changeIcon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite mute, unmute;
    [SerializeField] private Button button;

    bool durum = true;
    void Start()
    {
        button.onClick.AddListener(() =>
        {
            
            if (durum)
            {
                durum = !durum;
                button.image.sprite = mute;
            }
            else
            {
                durum = !durum;
                button.image.sprite = unmute;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void icondegistir()
    {
        if (durum)
        {
            button.image.sprite = mute;
        }
        else
        {
            button.image.sprite = unmute;
        }
        
    }
}
