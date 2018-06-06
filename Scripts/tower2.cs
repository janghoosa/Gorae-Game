using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class tower2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject menu;
    Vector3 movement;
    public float speed = 20f;
    Rigidbody2D t_rigidbody;
    float jump = 0f;
    int frame = 0;
    bool isgameover = false;
    bool ispaused = false;
    public int level;

    void Start()
    {
        Time.timeScale = 1.0f;
        t_rigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (!ispaused)
        {
            // UnityEngine.Debug.Log(jump + ":::::" + frame + ":::::" + t_rigidbody.velocity);
            Move(h, v);
            Turning2();
            frame++;

            if (Input.GetMouseButton(0) && frame % 10 == 0)
            {
                Fire();
            }

            if (transform.position.y < -100f && !(isgameover))
            {
                isgameover = true;

                GameObject.Find("Main Camera").GetComponent<menu2>().gameovered();
            }

            if (Input.GetKey(KeyCode.F))
            {
                SceneManager.GetActiveScene();
                //UnityEngine.Debug.Log("f");
            }
        }
    }

    public void setpaused()
    {
        ispaused = true;
    }
    public void unsetpaused()
    {
        ispaused = false;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        //UnityEngine.Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "wall")
        {
            jump = 0;
            //UnityEngine.Debug.Log("grounded");
        }

        if (col.gameObject.tag == "thorn")
        {
            isgameover = true;
            // UnityEngine.Debug.Log("thorn");
            SceneManager.LoadScene("game_over");
        }

        if (col.gameObject.tag == "enemy")
        {
            isgameover = true;
            // UnityEngine.Debug.Log("grounded");
            SceneManager.LoadScene("game_over");
        }

        if (col.gameObject.tag == "Finish")
        {
            UnityEngine.Debug.Log("clear");
            SceneManager.LoadScene(level + 1);
            
            // GameObject.Find("Main Camera").GetComponent<menu>().gameovered();
        }
    }

    void Move(float h, float v)
    {
        if (v == 1 && jump != 1 && frame > 17)
        {
            t_rigidbody.velocity = new Vector2(0, 13000f * Time.deltaTime);
            jump++;
            frame = 0;
        }
        else
        {
            movement.Set(h, 0f, 0f);
            movement = movement.normalized * speed * Time.deltaTime;
            transform.position = transform.position + movement;
        }
    }

    void Turning()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;
        mousePos -= transform.position;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // UnityEngine.Debug.Log(mousePos + " " + transform.position + Screen.width + "::" + Screen.height);
    }

    void Turning2()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        //UnityEngine.Debug.Log(screenPoint + " ::::" + offset + " ::::" +Input.mousePosition );

        float angle = Mathf.Atan2(-(offset.y), -(offset.x)) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position,
            transform.rotation);

        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 300f;
        Destroy(bullet, 2.0f);
    }
}
