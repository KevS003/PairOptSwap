using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameTracker : MonoBehaviour
{
    [SerializeField]
    private int score;
    [SerializeField]
    private float timer;
    //update score and timer UI 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    private float timeBonus;
    private float timeSub;

    //Handle time additions/subtractions in functions here. 
    public void Scored()
    {
        score++;
        timerText.text = "Score: "+ score;
        if(score % 5 == 0)
        {
            timeAddSub(true);
        }

        //update UI here
    }
    public void timeAddSub(bool adding)
    {
        if(adding)
            timer += timeBonus;
        else
            timer-= timeSub;
    }
    private void Update() 
    {
        //count timer here
        //update timer UI here
        //call lose condition here 
        //bring up total score here too
        timer-= Time.deltaTime;
        if(timer <= 0)
        {
            //lose and restart options here
        }   
    }

}
