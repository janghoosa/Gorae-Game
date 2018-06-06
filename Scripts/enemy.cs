using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    public int hp;
    public int velocity;
    Transform player;
    float timer;
    public GameObject bulletPrefab;
    public float timeBetweenBullets = 1.0f;

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (hp == 0)
        {
            Destroy(this.gameObject);
        }

        if (timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            fire();
        }
    }

    public void attacked()
    {
        hp--;
    }

    void fire()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = 0f;
        Vector3 offset = transform.position - player.position;

        float angle = Mathf.Atan2(-(offset.y), -(offset.x)) * Mathf.Rad2Deg;
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * velocity;
        Destroy(bullet, 4.0f);
        if (hp == 0)
        {
            Destroy(bullet);
        }
    }
}
