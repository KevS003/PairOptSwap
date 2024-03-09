using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemySpeed;
    private Vector3 directionS;//give a +-1 to either y or x to determine movement direction, that number is what is multiplied on update to move
    private SpriteRenderer spriteRef;
    private BoxCollider2D enemyBody;
    
    public void SetUpEnemy(Vector3 direction)//this gets set by spawner as they grab an object from the pool to find the direction
    {
        //direction*=enemySpeed;
        Debug.Log("enemy direction "+ directionS);
        gameObject.GetComponent<EnemyHealth>().enemyHealth = gameObject.GetComponent<EnemyHealth>().enemyHealthOG;
        directionS = direction;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        //enemyAudio = GetComponent<AudioSource>();  
        GetComponent<BoxCollider2D>().enabled = true; 

    }
    private void Update() 
    {
        if(directionS != Vector3.zero)
            transform.position += directionS*enemySpeed*Time.deltaTime;
    }

    
}
