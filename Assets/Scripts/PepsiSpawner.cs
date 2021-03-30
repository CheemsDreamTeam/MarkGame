using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepsiSpawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    float timer = 0f;
    int direction = 1;
    bool right;
    bool pepsiExists;


    // Use this for initialization
    void Start()
    {
        timer = 0;
    }

    void SpawnMe()
    {
        GameObject pepsi;
        if (right)
        {
             pepsi = (GameObject)Instantiate(spawnPrefab, transform.position + new Vector3(0.4f, -0.4f, 0), transform.rotation);
        }
        else
        {
             pepsi = (GameObject)Instantiate(spawnPrefab, transform.position + new Vector3(-0.4f, -0.4f, 0), transform.rotation);
        }

        float xVel = 5 + direction * transform.GetComponent<Rigidbody2D>().velocity.x;
        pepsi.GetComponent<Rigidbody2D>().velocity = new Vector2(direction * xVel, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            if (!pepsiExists)
            {
                SpawnMe();
                timer = 0;
                pepsiExists = true;
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
        timer += Time.deltaTime;
        if(timer > 2.5)
        {
            pepsiExists = false;
        }
    }


}
