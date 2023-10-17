using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baslatıcı : MonoBehaviour
{
    public GameObject hikaye = null;
    void Start()
    {
        Invoke("animgir",5f);
    }

    void animgir()
    {

        hikaye.SetActive(true);
    }
}
