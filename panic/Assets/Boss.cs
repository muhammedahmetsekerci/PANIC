using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Boss : MonoBehaviour
{
    private bool enemyDirection=false;
    public Animator animator;
    public Transform[] IsinlanmaNoktalari;
    bool kos,hasarAldi=false;
    public int can=3;
    public GameObject Player;
    
    void Update()
    {
        if(kos)
        {
            KosmayaBasla();
            Invoke("Secim",2f);
            kos=false;
        }
    }
    void bossYon()
    {
        if(transform.position.x>Player.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX=true;
        }
        else{GetComponent<SpriteRenderer>().flipX=false;}
    }
    public void Secim()
    {
        int randomNum = Random.Range(0, 2);
        
        HareketiCagir(randomNum);
    }
    public void HareketiCagir(int randomNum)
    {
        if(randomNum==0)
        {
            int randomNum1 = Random.Range(0, 3);
            animator.SetTrigger("boss");
            gameObject.transform.position=IsinlanmaNoktalari[randomNum1].position;
            animator.SetTrigger("yenidendogus");
            bossYon();
            

        }
        if(randomNum==1)
        {
            KosmayaBasla();
            kos=true;
        }
        
    }
    void KosmayaBasla()
    {
        bossYon();
        float value=(enemyDirection)?-1f:1f;
        transform.localScale=new Vector2(-value,1);
        float valueX=transform.position.x+value;
                
        Vector3 newPosition = transform.position + new Vector3(value * Time.deltaTime, 0, 0);
        moveEnemy();
        transform.position = newPosition;
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
            Secim();
            animator.SetTrigger("vurus"); 
            
        }
        if(other.CompareTag("yumruk"))
        {
            animator.SetTrigger("hasarAlma");
            
            can-=1;
            hasarAldi=false;
            if(can==0)
            {
                animator.SetTrigger("boss");//ölüm
                Invoke("passToSonSahne", 5f);
                transform.position=new Vector2(0,-500f);
               
            }
            else
                {Invoke("yuru",1f);}
        }
    }
    void passToSonSahne(){
        SceneManager.LoadScene("SON");


    }
}
