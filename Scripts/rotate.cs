using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
    float timer;
    public float velocity;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer > 3)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, (timer-5)*velocity));
        }    
    }
}
