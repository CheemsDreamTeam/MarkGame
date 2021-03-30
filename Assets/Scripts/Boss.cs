using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public int hp;
    public float timer;
    public bool isRed;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        hp = 20;
        isRed = false;
        sr = GetComponent<SpriteRenderer>();
    }


    public void flashRed()
    {
        timer = 0;
        sr.color = Color.red;
    }
    // Update is called once per frame
    void Update()
    {
        if (hp == 0)
        {
            Destroy(gameObject);
        }
        if(timer < 0.1)
        {
            timer += Time.deltaTime;
        }
        else
        {
            sr.color = Color.white;
        }
    }
}
