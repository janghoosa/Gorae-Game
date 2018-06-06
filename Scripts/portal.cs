using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour {
    public GameObject portalprefeb;

	// Use this for initialization
	void Start () {
        portalprefeb.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            portalprefeb.SetActive(true);
        }
       // UnityEngine.Debug.Log(GameObject.FindGameObjectsWithTag("enemy").Length == 0);
	}
}
