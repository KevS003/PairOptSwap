using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;
    [HideInInspector]
    public int enemyHealthOG;
    private BoxCollider2D enemyBody;
    private AudioSource enemyAudio;
    public AudioClip damageAudio;
    public AudioClip deathSound;
    public GameObject[] splatType;
    public Quaternion rotation = Quaternion.identity;
    private SpriteRenderer spriteRef;
    private bool dead;
    public GameTracker scoreRef;

    //instantiate a gameobject that has a script to fade out and destroy particles on screen
    //use an array of random PNGs to spawn and despawn
    //place ref to game manager here to detect death and add to score

    private void Awake() 
    {
        enemyHealthOG = enemyHealth;
        scoreRef = FindFirstObjectByType<GameTracker>();//Turned to first obj and moved the dude to the top to get a quicker ref
        spriteRef = gameObject.GetComponent<SpriteRenderer>();
        enemyAudio = GetComponent<AudioSource>();  
        enemyBody = GetComponent<BoxCollider2D>(); 
        
    }
    public void TookDamage(int damage)//call this function if cast detects it in statemachine
    {
        //trigger damage color shift
        enemyHealth -= damage;

        if(enemyHealth <=0 && dead == false)
        {
            //instantiate particle effect
            dead = true;
            StartCoroutine(Death());
            //DeathPool();
            //play death sound
            //return true;//if dead
            //destroy object
            
        }
        if(dead == false)
            StartCoroutine(DamageEffect());
            //DamageEffectPool();
            
        //return false;//if not dead
        
    }
    private IEnumerator DamageEffect()
    {
        enemyAudio.PlayOneShot(damageAudio);
        //change color of object
        spriteRef.color = Color.red;
        //play sound
        Debug.Log("Dmg effect");
        yield return new WaitForSeconds(.5f);
    }
    private IEnumerator Death()
    {
        enemyAudio.PlayOneShot(deathSound);
        spriteRef.enabled = false;
        enemyBody.enabled = false;
        scoreRef.Scored();
        Instantiate(splatType[Random.Range(0, splatType.Length)], transform.position,rotation);
        yield return new WaitForSeconds(.5f);
        dead = false;
        gameObject.SetActive(false);
        //Destroy(gameObject);
        
    }

    /* public void DeathPool()
    {
        enemyAudio.PlayOneShot(deathSound);
        spriteRef.enabled = false;
        enemyBody.enabled = false;
        //scoreRef.Scored();
        Instantiate(splatType[Random.Range(0, splatType.Length)], transform.position,rotation);
        gameObject.SetActive(false);
    }
    public void DamageEffectPool()
    {
        enemyAudio.PlayOneShot(damageAudio);
        //change color of object
        spriteRef.color = Color.red;
    } */
    
}
