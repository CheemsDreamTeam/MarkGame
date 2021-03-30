using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    float timer = 0f;
    int direction = 1;
    bool right;


    // Use this for initialization
    void Start()
    {
        timer = 0;
        right = true;
    }

    void SpawnMe()
    {
        GameObject boolet = (GameObject)Instantiate(spawnPrefab, transform.position + new Vector3(0.4f * (right ? 1:-1), -0.55f, 0 ), transform.rotation);
        float xVel = 10 + direction*transform.GetComponent<Rigidbody2D>().velocity.x;
        boolet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction* xVel, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            timer += Time.deltaTime;
            if (timer > .3)
            {
                SpawnMe();
                timer = 0;
            }

        }

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
        {
            if (right)
            {
                right = false;
                direction = -1;
            }
        }

        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
        {
            if (!right)
            {
                right = true;
                direction = 1;
            }
        }
    }


}
