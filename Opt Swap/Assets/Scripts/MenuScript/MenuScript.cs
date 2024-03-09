using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject menu;
    private void Start() 
    {
        Time.timeScale = 0;    
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        Time.timeScale = 1;
        menu.SetActive(false);

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
