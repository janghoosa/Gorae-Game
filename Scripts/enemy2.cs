using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public int hp;
    public int velocity;
    Transform player;
    float timer;
    public GameObject bulletPrefab;
    public float timeBetweenBullets = 0.3f;
    float btimer;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        btimer += Time.deltaTime;

        if (hp == 0)
        {
            Destroy(this.gameObject);
        }

        if (timer >= timeBetweenBullets && Time.timeScale != 0 && btimer> 2)
        {
            fire();
        }
        if(btimer > 3)
        {
            btimer = 0;
        }
    }

    public void attacked()
    {
        hp--;
    }

    void fire()
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
