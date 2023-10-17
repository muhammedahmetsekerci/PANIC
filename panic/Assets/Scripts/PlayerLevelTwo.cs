using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevelTwo : MonoBehaviour
{
    [SerializeField]
    private float health;

    [SerializeField]
    private TextMeshProUGUI healthText;


    public event EventHandler onGameWin;
    public event EventHandler onGameLost;

    private float timer;

    [SerializeField]
    private float timerMax = 120f;

    private bool once = true;
    public static PlayerLevelTwo Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        healthText.text=health.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Meteor")
        {
            health--;
            healthText.text = "X" + health;

            if(health<=0)
            {
                onGameLost?.Invoke(this,EventArgs.Empty);
                Invoke("meteorYukle", 5f);
                
            }
        }
    }
    public void meteorYukle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        
        if (timer < timerMax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if(once)
            {
                onGameWin?.Invoke(this, EventArgs.Empty);
                once = false;
            }
        }
    }
}
