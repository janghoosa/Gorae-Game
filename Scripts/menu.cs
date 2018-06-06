using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menu : MonoBehaviour {
    public int stage;
    public GameObject PauseUI;
    public GameObject go;
    //public GameObject GameoverUI;
    private bool paused = false;
    //private bool gameovered = false;
    private float rate = 0.2f;
    private float next = 0.0f;

    void Start()
    {
        Time.timeScale = 1.0f;
        PauseUI.SetActive(false);
        //GameoverUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P) && Time.time > next)
        {
            next = Time.time + rate;
            paused = true;
        }
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
            if (GameObject.Find("tower_s"))
            {
                GameObject.Find("tower_s").GetComponent<Tower>().setpaused();
            }
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1f;
            if (GameObject.Find("tower_s"))
            {
                GameObject.Find("tower_s").GetComponent<Tower>().unsetpaused();
            }
            
        }
        //if (gameovered)
        //{
        //    GameoverUI.SetActive(true);
        //    Time.timeScale = 0f;
        //}
    }

    public void resume()
    {
        paused = false;
    }

    public void Restaret()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        //SceneManager.LoadScene("game_menu");
        SceneManager.LoadScene(0);
    }
    public void gameovered()
    {
        //SceneManager.LoadScene("game_menu");
        go.GetComponent<gameover>().goshow();
    }

    public void stageset()
    {
        SceneManager.LoadScene("stage");
    }

    //public void gameover1()
    //{
    //    gameovered = true;
    //}
}
