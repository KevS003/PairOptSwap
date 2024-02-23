using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    /* PlayerStateManager playerRef;
    private float speedRef;
    Rigidbody2D rbRef;
    public PlayerMoveState(PlayerStateManager player,float speed, Rigidbody2D rb)
    {
       playerRef = player;
       speedRef = speed;
       rbRef = rb;

    } */
    
    
    Rigidbody2D rb;
    Vector2 noMoveRef = Vector2.zero;
    float speed;
    //private bool isFacingRight = true; in case I use flippable sprite
    //bool checkingIdle;
    public override void EnterState(PlayerStateManager player)
    {
        //Debug.Log("I move now");
        //speed = player.speed;
        rb = player.rb; 

    }
    public override void tick(PlayerStateManager player)
    {
        player.moveInput.Normalize();
        rb.velocity = player.moveInput*player.speed;//This could be better. Checks speed constantly while in state. Scuffed it for now.
        //Debug.Log(player.moveInput*speed);
        if(player.moveInput == noMoveRef)
        {
            player.SwitchState(player.IdleState);
        }
        //add a dash transition here

    }

    public override void OnExit(PlayerStateManager player)
    {
        //Debug.Log("I done moving");
    }
    /* private IEnumerator IdleSwitch()
    {
        yield return new WaitForSeconds(1);

    } */

    

  
}
