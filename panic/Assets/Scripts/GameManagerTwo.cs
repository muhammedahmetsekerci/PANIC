using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManagerTwo : MonoBehaviour
{
    [SerializeField]
    private Sprite[] meteorSprites;

    [SerializeField]
    private Image[] meteors;

    [SerializeField]
    private GameObject lostUI;

    [SerializeField]
    private Animator carAnimator;

    [SerializeField]
    private PlayerControl playerControl;

    [SerializeField]
    private Car car;

    public static GameManagerTwo Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PlayerLevelTwo.Instance.onGameWin += playerOnGameWin;
        PlayerLevelTwo.Instance.onGameLost += playerOnGameLost;

        lostUI.SetActive(false);
        for (int i=0;i<meteors.Length; i++)
        {
            meteors[i].gameObject.GetComponent<Image>().sprite = meteorSprites[UnityEngine.Random.Range(0,meteorSprites.Length)];
            Vector2 position = new Vector2(UnityEngine.Random.Range(-16f,16), UnityEngine.Random.Range(7f,13f));

            meteors[i].transform.position = position;
        }

        
    }

    private void playerOnGameLost(object sender, EventArgs e)
    {
        lostUI.SetActive(true);
        carAnimator.speed = 0f;
    }

    private void playerOnGameWin(object sender, EventArgs e)
    {
        Debug.Log("You Win");
        Debug.Log("Araba ile kacis");
        carAnimator.SetTrigger("IsDrive");
        
    }

    
}
