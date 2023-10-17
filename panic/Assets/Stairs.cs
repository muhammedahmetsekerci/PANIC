using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float moveSpeed=1f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            animator.SetTrigger("IsJump");
            
            Vector2 inputVectorNormalized = other.gameObject.GetComponent<PlayerControl>().gameInput.GetInputVectorNormalized();
            if(inputVectorNormalized.y>0)
            {
                
                Vector3 newPosition = transform.position;
                newPosition.y += inputVectorNormalized.y* moveSpeed * Time.deltaTime;
                transform.position = newPosition;
            }
            else{
                Vector3 newPosition = transform.position;
                newPosition.y += inputVectorNormalized.y * moveSpeed * Time.deltaTime;
                transform.position = newPosition;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
    }
}
