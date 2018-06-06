using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectsWithTag("enemy") == null)
        {
            Destroy(this);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //UnityEngine.Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "enemy")
        {
            if (col.gameObject.GetComponent<enemy>())
            {
                col.gameObject.GetComponent<enemy>().attacked();
            }
            if (col.gameObject.GetComponent<enemy2>())
            {
                col.gameObject.GetComponent<enemy2>().attacked();
            }
            if (col.gameObject.GetComponent<enemyboss>())
            {
                col.gameObject.GetComponent<enemyboss>().attacked();
            }
            Destroy(this.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        UnityEngine.Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "enemy")
        {
            col.gameObject.GetComponent<enemy>().attacked();
            Destroy(this.gameObject);
        }
    }

}
