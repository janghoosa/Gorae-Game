using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class bullet_e2 : MonoBehaviour {
    float timer = 0;
    float timeBetweenBullets = 0.4f;
    Transform player;
    Rigidbody2D rigidbody2d;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            tracking();
        }
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            Destroy(this);
        }

    }

    void tracking()
    {
        timer = 0f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 offset = transform.position - player.position;
        float angle = Mathf.Atan2(-(offset.y), -(offset.x)) * Mathf.Rad2Deg;
        this.transform.rotation = (Quaternion.Euler(new Vector3(0, 0, angle)));
        this.GetComponent<Rigidbody2D>().velocity = transform.right * 80f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //UnityEngine.Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("game_over");
        }
    }

}
