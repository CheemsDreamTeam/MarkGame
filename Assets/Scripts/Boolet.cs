using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 1f);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground")){
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
            Boss b = other.gameObject.GetComponent<Boss>();
            b.hp--;
            b.flashRed();
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
