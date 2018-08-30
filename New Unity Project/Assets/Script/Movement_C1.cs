using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_C1 : MonoBehaviour {

    public float moveSpeed = 10;
    public float jumpPower = 300;
    private int jumpTime = 0;


    public Rigidbody2D rigid2D;

    public Transform firePoint;
    public GameObject Ball;

    public float shotDelay;
    private float shotDealyCounter;


    void Start()
    {
        rigid2D = gameObject.GetComponent< Rigidbody2D >();
    }


    void Update()
    {
        Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(new Vector2(moveSpeed, 0));
        }

        else if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(new Vector2(-moveSpeed, 0));

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (jumpTime < 2)
            {
                rigid.AddForce(new Vector2(0, jumpPower));
                jumpPower += 0;
                jumpTime += 1;
                print(jumpTime);
            }

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Ball, firePoint.position, firePoint.rotation);
            shotDealyCounter = shotDelay;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            shotDealyCounter -= Time.deltaTime;

            if (shotDealyCounter <= 0)
            {
                shotDealyCounter = shotDelay;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D hitwith)
    {
        if (hitwith.gameObject.CompareTag("floor"))
        {
            jumpTime = 0;
        }

    }
    void OnCollisionStay2D(Collision2D hitwith)
    {

    }
    void OnCollisionExit2D(Collision2D hitwith)
    {
        print("Our character stop to collide with " + hitwith.gameObject.name);
    }
}
