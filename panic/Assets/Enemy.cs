using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool enemyDirection=false;
    private bool hasarAldi =true;
    private Animator animator;
    //public GameObject ZombiKafaCevirme;
    private int can= 3;
    private float timer;
    private float timerMax=3f;


    void Start()
    {
        animator=GetComponent<Animator>();     
        
    }

    
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>=timerMax)
        {
            timer=0f;
            enemyDirection=!enemyDirection;
        }
        else
        {
            if(hasarAldi)
            {
                float value=(enemyDirection)?-1f:1f;
                transform.localScale=new Vector2(-value,1);
                float valueX=transform.position.x+value;
                
                Vector3 newPosition = transform.position + new Vector3(value * Time.deltaTime, 0, 0);
                moveEnemy();
                transform.position = newPosition;
            } 
        }
    }

    private void moveEnemy(){
        if(enemyDirection){
            GetComponent<SpriteRenderer>().flipX=enemyDirection;
            animator.SetTrigger("walk");
            
        }
        else{
            GetComponent<SpriteRenderer>().flipX=!enemyDirection;
            animator.SetTrigger("walk");
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            
            animator.SetTrigger("hit"); 
            
        }
        if(other.CompareTag("yumruk"))
        {
            animator.SetTrigger("hasar");
            //Vector2 newPosition;
            // if(!enemyDirection)
            // {
            //     newPosition=new Vector2(transform.position.x-0.5f,transform.position.y);
            // }
            
            // else{
            //     newPosition=new Vector2(transform.position.x+0.5f,transform.position.y);
            //     }
            // transform.position=newPosition;
            can-=1;
            hasarAldi=false;
            if(can==0)
                {animator.SetTrigger("olum");
                
                Destroy(gameObject, 0.7f);}
            else
                {Invoke("yuru",1f);}
        }
    }
    private void yuru()
    {
        hasarAldi=true;
    }
    
}
