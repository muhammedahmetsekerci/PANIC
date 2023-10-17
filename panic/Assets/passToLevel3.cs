using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class passToLevel3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("passLevel3", 48f);
    }
    void passLevel3()
    {
        SceneManager.LoadScene("ZombieKarakteriAl");
    }

}
