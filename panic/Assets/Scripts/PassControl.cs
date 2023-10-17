using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassControl : MonoBehaviour
{
    private void Awake()
    {
        Invoke("meteorSahne", 3f);
    }
    public void meteorSahne()
    {
        SceneManager.LoadScene("MeteorMovie");
    }
    
}
