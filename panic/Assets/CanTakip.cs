using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class CanTakip : MonoBehaviour
{
        
    [SerializeField]
    private float health;
        [SerializeField]
    private TextMeshProUGUI healthText;
    // Start is called before the first frame update
    private void Start()
    {
        healthText.text=health.ToString();
    }

    public void CanDusur()
    {
        health--;
        healthText.text = "X" + health;
        if(health==0)
        {
            SceneManager.LoadScene(4);
        }
    }
}
