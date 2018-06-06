using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gameover : MonoBehaviour {
    //public GameObject PauseUI;
    //private bool paused = false;

    
    void Start()
    {
    }
    void Update()
    {
       
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }

    public void goshow()
    {
        this.gameObject.SetActive(true);
    }
    //public void Resume()
    //{
    //    paused = false;
    //}
    //public void Restaret()
    //{
    //    SceneManager.LoadScene("game_1");
    //}
    //public void MainMenu()
    //{
    //    SceneManager.LoadScene(1);
    //}
    //public void Quit()
    //{
    //    Application.Quit();
    //}

}
