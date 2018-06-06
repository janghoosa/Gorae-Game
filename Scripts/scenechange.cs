using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scenechange : MonoBehaviour {
    public bool game_over = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void scene_gameover()
    {
        SceneManager.LoadScene("game_over", LoadSceneMode.Additive);
    }
    
}
