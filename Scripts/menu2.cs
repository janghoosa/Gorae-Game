using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menu2 : MonoBehaviour
{
    public GameObject PauseUI;
    public int stage;
    private bool paused = false;
    private float rate = 0.2f;
    private float next = 0.0f;

    void Start()
    {
        Time.timeScale = 1.0f;
        PauseUI.SetActive(false);
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
                GameObject.Find("tower_s").GetComponent<tower2>().setpaused();
            }
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1f;
            if (GameObject.Find("tower_s"))
            {
                GameObject.Find("tower_s").GetComponent<tower2>().unsetpaused();
            }

        }
    }

    public void resume()
    {
        paused = false;
    }

    public void Restaret()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        //SceneManager.LoadScene("game_menu");
        SceneManager.LoadScene(0);
    }
    public void gameovered()
    {
        SceneManager.LoadScene("game_over");
    }
}
