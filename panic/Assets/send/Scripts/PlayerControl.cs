using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    public CanTakip _CanTakip;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float moveSpeed = 7f;

    private bool isWalking;

    private bool isJumping;
    
    public GameInput gameInput;

    [SerializeField]
    private SoundManager soundManager;

    [SerializeField]
    private AudioSource audioSource;

    private double enoughDistance=1f;

    public static PlayerControl Instance{get; set; }

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    private bool key;
    // Start is called before the first frame update
    void Start()
    {
        gameInput.onTVInteract+=gameInputOnTVIneract;
        gameInput.onHit+=gameInputOnHit;
    }
    // Update is called once per frame
    void Update()
    {
       HandleMove();
    }

    private void HandleMove()
    {
        Vector2 inputVector = gameInput.getMovementNormalized();

            if(inputVector.x>0)
            {
                GetComponent<SpriteRenderer>().flipX=false;            
            }
            if(inputVector.x<0)
            {
                GetComponent<SpriteRenderer>().flipX=true;            
            }

        Vector3 moveDirection = new Vector3(inputVector.x,inputVector.y,0f);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if(isWalking)
        {
            soundManager.playWalkSound();
            MoonWalk();
        }
        else
        {
            MoonWalkStop();
            //MoonJumpFall();
            if (isJumping)
            {
                soundManager.plaJumpSound(); 
                MoonJump();
            }
            else
            {
                audioSource.Stop();  
                
            }
            
        }

        /*float rotateSpeed = 10f;

        transform.forward = Vector3.Slerp(transform.forward,moveDirection,Time.deltaTime*rotateSpeed);*/
    }

    public bool getIsWalking()
    {
        return isWalking;
    }

    public void setIsWalking(bool isWalk)
    {
        isWalking=isWalk;
    }

    public bool getIsJumping()
    {
        return isWalking;
    }

    public void setIsJumping(bool isJump)
    {

        isJumping = isJump;
    }

    private void MoonWalk()
    {
        animator.SetBool("IsWalk",true);
    }
    private void MoonWalkStop()
    {
        animator.SetBool("IsWalk",false);
    }
    private void MoonJump()
    {
        animator.SetTrigger("IsJump");
    }
    private void MoonJumpFall()
    {
        animator.SetTrigger("IsJump");
    }

    private void gameInputOnTVIneract(object sender,EventArgs e)
    {
        GameObject tv=FindObjectOfType<TV>().gameObject;
        if(Mathf.Abs(transform.position.x-tv.transform.position.x)<enoughDistance && Mathf.Abs(transform.position.y-tv.transform.position.y)<enoughDistance)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void gameInputOnHit(object sender,EventArgs e)
    {
        animator.SetTrigger("yumruk"); 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Zombi"))
        {
            animator.SetTrigger("Yaralanma");
            _CanTakip.CanDusur();
        }
    }
    
}
