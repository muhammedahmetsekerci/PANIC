using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrier : MonoBehaviour
{
    public event EventHandler<onMeteorFellEventArgs> onMeteorFell;

    public class onMeteorFellEventArgs : EventArgs
    {
        public GameObject gameObject;
    } 
    public static Barrier Instance { get; private set; }

    [SerializeField]
    private Sprite[] meteorSprites;

    private void Awake()
    {
        Instance = this;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            collision.gameObject.GetComponent<Image>().sprite= meteorSprites[UnityEngine.Random.Range(0, meteorSprites.Length)];
            onMeteorFell?.Invoke(this, new onMeteorFellEventArgs { gameObject=collision.gameObject}) ;
        }
    }


}
