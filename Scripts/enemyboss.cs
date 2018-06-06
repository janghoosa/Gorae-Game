using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyboss : MonoBehaviour
{
    public int hp;
    public int velocity;
    Transform player;
    Rigidbody2D rigid;
    float timer;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public float timeBetweenBullets;
    public float timeBetweenBullets2;
    float btimer;
    bool once = true;
    bool once2 = true;
    int phase = 1;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
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

        if (timer >= timeBetweenBullets && Time.timeScale != 0 && btimer > 1 && phase == 1)
        {
            if (once)
            {
                rigid.velocity = transform.up * 9f;
                once = false;
            }
            if (transform.position.y > 60)
            {
                rigid.velocity = transform.up * -9f;
            }
            if (transform.position.y < -40 && rigid.velocity.y == -9f)
            {
                rigid.velocity = new Vector2(0, 0);
                phase = 2;
            }

            fire1();
        }

        if (timer >= timeBetweenBullets2 && Time.timeScale != 0 && btimer > 1 && phase == 2)
        {
            if (once2)
            {
                rigid.velocity = transform.up * 9f;
                once2 = false;
            }
            if (transform.position.y > 60)
            {
                rigid.velocity = transform.up * -9f;
            }
            if (transform.position.y < -40 && rigid.velocity.y == -9f)
            {
                rigid.velocity = new Vector2(0, 0);
                phase = 1;
            }
            fire2();
        }
        if (btimer > 3)
        {
            btimer = 0;
        }
    }


    public void attacked()
    {
        hp--;
        UnityEngine.Debug.Log(hp);
    }

    void fire1()
    {
        timer = 0;
        for (int i = 0; i < 8; i++)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, i * 8f + 170)));
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * velocity;
            Destroy(bullet, 4.0f);
        }
    }

    void fire2()
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 offset = transform.position - player.position;

        float angle = Mathf.Atan2(-(offset.y), -(offset.x)) * Mathf.Rad2Deg;
        GameObject bullet = (GameObject)Instantiate(bulletPrefab2, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * velocity;
        Destroy(bullet, 4.0f);
        if (hp == 0)
        {
            Destroy(bullet);
        }
    }
}
