using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_10 : MonoBehaviour
{
    public GameObject portalprefeb;
    public GameObject massage;
    public GameObject whale1;
    public GameObject whale2;
    public GameObject whale3;
    bool make = false;
    // Use this for initialization
    void Start()
    {
        whale1.SetActive(false);
        whale2.SetActive(false);
        whale3.SetActive(false);
        massage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0 && !make)
        {
            whale1.SetActive(true);
            whale2.SetActive(true);
            whale3.SetActive(true);
            massage.SetActive(true);
            make = true;
        }
        // UnityEngine.Debug.Log(GameObject.FindGameObjectsWithTag("enemy").Length == 0);
    }
}
