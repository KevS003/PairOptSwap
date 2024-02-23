using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 moveInput;

    private float horizontal;
    private float vertical;
    public float speed = 8f;
    public float dashPower = 2f;
    private bool isFacingRight = true;
    private bool dashing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()//tick for the move state
    {
        moveInput.Normalize();
        rb.velocity = moveInput*speed;
            //dashing = false;
        
            

        if(!isFacingRight && horizontal >0f)
        {
            Flip();
        }
        else if(isFacingRight&& horizontal < 0f)
        {
            Flip();
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    /* public void Dash(InputAction.CallbackContext context)
    {
        
        //dashing = true;
        Debug.Log("We dash?");
        if(context.performed) //does a full dash
        {
            Debug.Log("We Dash");
            //speed = dashPower;
            Debug.Log(moveInput*(speed+dashPower));
            
        }
        if(context.canceled)//Does half a dash
        {
            Debug.Log("We Dash/2");
             rb.AddForce(moveInput * dashPower * 0.5f, ForceMode2D.Impulse);
             
        }
        //dashing = false;
        
    } */
    public void Move(InputAction.CallbackContext context)
    {
        moveInput.x = context.ReadValue<Vector2>().x;
        moveInput.y = context.ReadValue<Vector2>().y;
        Debug.Log(moveInput*speed);

    }

}
