using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDashState : PlayerBaseState
{
    PlayerStateManager playerRef;
    float speedRef;
    float dashPowerRef;
    Rigidbody2D rb;
    bool dashed;

    /* public PlayerDashState(PlayerStateManager player, float speed, float dashPower, Rigidbody2D rb)
    {
        playerRef = player;
        speedRef = speed;
        dashPowerRef= dashPower;
        rbRef = rb;
    } */
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I dash now");
        rb = player.rb;
        dashPowerRef = player.dashPower;
    }
    public override void tick(PlayerStateManager player)
    {
        if(dashed == false)
        {
            rb.AddForce(player.moveInput * dashPowerRef * 0.5f, ForceMode2D.Impulse);
            dashed = true;
        }
        //Dash once then return to move state. 

    }

    public override void OnExit(PlayerStateManager player)
    {
        
    }
    /* private IEnumerator SwapBack()
    {
        yield return new WaitForSeconds(.5f);
        playerRef.SwitchState(playerRef.MoveState);
        dashed = false;
    } */

    
}
