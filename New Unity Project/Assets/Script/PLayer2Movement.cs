using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer2Movement : MonoBehaviour {

    public float moveSpeed = 10;
    public float jumpPower = 300;
    private int jumpTime = 0;


    public Rigidbody2D rigid2D;

    public Transform firePoint;
    public GameObject Ball;


    void Start()
    {
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.AddForce(new Vector2(moveSpeed, 0));
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.AddForce(new Vector2(-moveSpeed, 0));

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumpTime < 2)
            {
                rigid.AddForce(new Vector2(0, jumpPower));
                jumpPower += 0;
                jumpTime += 1;
                print(jumpTime);
            }

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(Ball, firePoint.position, firePoint.rotation);
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
