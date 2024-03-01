using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    
    

    private RaycastHit2D[] hits;
    public override void EnterState(PlayerStateManager player)
    {
        //Enter attack animation
        Debug.Log("Attacking");
        //play anim and sound here
        hits = Physics2D.CircleCastAll(player.attackTransform.position, player.attackRange, player.transform.forward, 0f, player.attackableLayer);
        if(hits!=null)
            DoDamage();


    }
    public override void tick(PlayerStateManager player)
    {
        //Swipe
        //Detect combo if ambitious
        

    }

    public override void OnExit(PlayerStateManager player)
    {
        //Leave if done
    }
    private void DoDamage()
    {
        for(int i=0; i<hits.Length; i++)
        {
            Debug.Log("Hit");
            //grab enemy health and subtract 

        }
    }

    
}
