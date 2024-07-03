using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerScript : MonoBehaviour

  
{
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver() 
    {
        gameOverUI.SetActive(true);
    }
    public void NewGame() 
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu() 
    {
        SceneManager.LoadScene(0);
    }
    public void closeGame() 
    {
        Application.Quit();
    }
}
