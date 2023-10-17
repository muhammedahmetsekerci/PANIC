using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private SpriteRenderer KarakterYon;

    public event EventHandler onTVInteract;
    public event EventHandler onHit;

    public static GameInput Instance{get;private set;} 
    void Start()
    {
        KarakterYon = GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        Instance =this;
        playerInputActions.Player.Move.performed+=interactPerformed;

        playerInputActions.Player.Interact.performed+=interactPerformed;
        playerInputActions.Player.InteractAlternate.performed+=interactAlternatePerformed;

    }

    public void interactPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        onTVInteract?.Invoke(this,EventArgs.Empty);
    }

    public void interactAlternatePerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        onHit?.Invoke(this,EventArgs.Empty);
    }
    public Vector2 GetInputVectorNormalized()
     {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
     }
    public Vector2 getMovementNormalized()
    {

        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;


        PlayerControl.Instance.setIsWalking(inputVector.x != 0&& inputVector.y ==0);
       if (inputVector.x > 0)
        {
            KarakterYon.flipX  =true;
            // Vector3 newScale = transform.localScale;
            // newScale.x = -1; // X eksenini ters çevirmek istiyorsanız -1 kullanabilirsiniz.
            // transform.localScale = newScale;
        }
        else
        {
            KarakterYon.flipX  =false;
            // Vector3 newScale = transform.localScale;
            // newScale.x = 1; // X eksenini normale çevirmek istiyorsanız 1 kullanabilirsiniz.
            // transform.localScale = newScale;
        }
        PlayerControl.Instance.setIsJumping(inputVector.y != 0);


        return inputVector;
    }
}
