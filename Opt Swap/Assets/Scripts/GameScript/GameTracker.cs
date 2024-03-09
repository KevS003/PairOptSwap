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
    public float timeBonus;
    public float timeSub;
    public GameObject endScreen;

    //Handle time additions/subtractions in functions here. 
    public void Scored()
    {
        score++;
        scoreText.text = "Score: "+ score;
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
        timerText.text = "TIME: "+timer.ToString("N0");
        if(timer <= 0)
        {
            //lose and restart options here
            timerText.text = "TIME: 0";
            GameOver();
        }   
    }

    private void GameOver()
    {
        endScreen.SetActive(true);
        Time.timeScale = 0;
    }

}
