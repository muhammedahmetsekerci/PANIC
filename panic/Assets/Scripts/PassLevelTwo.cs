using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassLevelTwo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadLevel2", 3f);
    }

    void LoadLevel2(){
        SceneManager.LoadScene("ChapterTwo");
    }
}
