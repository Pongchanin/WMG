using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_C1 : MonoBehaviour {

    //Player Attribute
    public float moveSpeed = 10;
    public float jumpPower = 300;
    private int jumpTime = 0;

    //Player Component
    public Rigidbody2D rigid2D;
    Transform characterTransform;
    public bool PlayerFacingRight;

    //Ball Attribute
    public Transform firePoint;
    public GameObject Ball;

    //Ball Behavior
    public float shotDelay;
    private float shotDealyCounter;

    


    void Start()
    {
        rigid2D = gameObject.GetComponent< Rigidbody2D >();
        characterTransform = gameObject.GetComponent<Transform>();
        PlayerFacingRight = true;
    }


    void Update()
    {
        Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(new Vector2(moveSpeed, 0));
            characterTransform.localScale = new Vector3(-0.8294058f, 0.8294058f, 0.8294058f);
            PlayerFacingRight = true;

        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rigid.AddForce(new Vector2(0, 0));
        }

        else if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(new Vector2(-moveSpeed, 0));
            characterTransform.localScale = new Vector3(0.8294058f, 0.8294058f, 0.8294058f);
            PlayerFacingRight = false;

        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            rigid.AddForce(new Vector2(0, 0));
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            characterTransform.position += new Vector3(0, 0.1f, 0);
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
