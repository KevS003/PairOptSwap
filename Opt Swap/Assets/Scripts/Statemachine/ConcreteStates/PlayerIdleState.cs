using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    Vector2 zeroCompare = Vector2.zero;
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Idling");
        
    }
    public override void tick(PlayerStateManager player)
    {
        Debug.Log("Idle animation playing");
        /* if(player.moveInput.x== zeroCompare.x || player.moveInput.y==zeroCompare.y)
        {
            player.SwitchState(player.MoveState);
        } */
    }

    public override void OnExit(PlayerStateManager player)
    {
        //could add something when state changes I guess idk
        Debug.Log("I leave now"); 
    }

    
}
