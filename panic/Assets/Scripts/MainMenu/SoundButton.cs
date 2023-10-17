using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{

    bool durum = false;


    public Button button; // Butonunuzu bu deðiþkene sürükleyip býrakarak atanabilirsiniz.
    public Sprite mute; // Yeni resim olarak kullanmak istediðiniz sprite'ý bu deðiþkene sürükleyip býrakarak atanabilirsiniz.
    public Sprite unMute;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void change()
    {
        durum = !durum;
        if (durum)
        {
            button.image.sprite = mute;
        }
        else
        {
            button.image.sprite = unMute;
        }
    }
}
