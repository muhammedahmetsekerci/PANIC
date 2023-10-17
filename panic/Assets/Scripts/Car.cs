using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Car : MonoBehaviour
{
    private float distance = 25f;

    public GameObject Collidertucu;
    private GameObject player;
    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            player = collision.gameObject;
            player.transform.position = new Vector3(distance, collision.gameObject.transform.position.y,0f);
            Invoke("waiter", 0.8f);
            
        }
          
    }

    private void waiter()
    {
        SceneManager.LoadScene("MeteorSonrasi");
    }


}
