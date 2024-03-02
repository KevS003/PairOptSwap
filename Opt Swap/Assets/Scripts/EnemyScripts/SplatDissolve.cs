using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatDissolve : MonoBehaviour
{
    // Start is called before the first frame update
    public float dissolveTime= 1f;
    private float dissolveDuration;
    private SpriteRenderer sRenderer;
    private Color originalColor;
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        dissolveDuration = dissolveTime;
        originalColor = sRenderer.color;
        //SplatAway();
    }
    private void Update() 
    {
        dissolveTime -= Time.deltaTime;

        if (dissolveTime <= 0f)
        {
            // Destroy the object or perform other actions when fading is complete
            Destroy(gameObject);
        }
        else
        {
            // Calculate the alpha value based on the remaining time
            float alpha = Mathf.Lerp(0f, originalColor.a, dissolveTime / dissolveDuration);

            // Update the sprite renderer's color with the new alpha value
            sRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
        }
    }
}
