using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
	private BoxCollider2D coll;
    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck, leftTopCheck, rightTopCheck, leftBotCheck, rightBotCheck;
    public float groundCheckRadius;
    public LayerMask ground;
    public LayerMask pepsi;
    public LayerMask wall;

    public bool grounded, leftWalled, rightWalled;

    public GameObject spawnPrefab;

    private Animator thisAnim;
    
    float timer = 0f;
	
	float distToGround;

    bool left;


    // Use this for initialization
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        timer = 0f;
		coll = GetComponent<BoxCollider2D>();
        thisAnim = transform.GetChild(6).GetComponent<Animator>();
        left = false;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground) || Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, pepsi);
        leftWalled = Physics2D.OverlapCircle(leftTopCheck.position, groundCheckRadius, wall) || (Physics2D.OverlapCircle(leftBotCheck.position, groundCheckRadius, wall) && !grounded);
        rightWalled = Physics2D.OverlapCircle(rightTopCheck.position, groundCheckRadius, wall) || (Physics2D.OverlapCircle(rightBotCheck.position, groundCheckRadius, wall) && !grounded);

    }

    void SpawnMe()
    {
        GameObject swing = (GameObject)Instantiate(spawnPrefab, transform.position, transform.rotation);
    }

    void Flip()
    {
            left = !left;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

    }

    // Update is called once per frame
    void Update() {

        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !rightWalled)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            thisAnim.SetBool("isWalking", true);
            //thisAnim.SetBool("left", false);
            if (left)
            {
                Flip();
            }
            


        }
        else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && !leftWalled)
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            thisAnim.SetBool("isWalking", true);
            //thisAnim.SetBool("left", true);
            if (!left)
            {
                Flip();
            }

        }
        else
        {
            thisAnim.SetBool("isWalking", false);
        }


        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && grounded)
        {
            rb2d.velocity = new Vector2(0, jumpHeight);
        }


    }
	
}
