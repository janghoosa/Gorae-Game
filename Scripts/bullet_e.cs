using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class bullet_e : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //UnityEngine.Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("game_over");
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        UnityEngine.Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
}
