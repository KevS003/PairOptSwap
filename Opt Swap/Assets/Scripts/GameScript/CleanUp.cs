using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("jhndsagjh;");
        if(other.gameObject.layer == 3)
        {
            other.gameObject.SetActive(false);
        }

            
            //Destroy(other.gameObject); 
    }
}
