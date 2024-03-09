using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public GameTracker gameTracker;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 3)
        {
            other.gameObject.SetActive(false);
            gameTracker.timeAddSub(false);
        }

            
            //Destroy(other.gameObject); 
    }
}
