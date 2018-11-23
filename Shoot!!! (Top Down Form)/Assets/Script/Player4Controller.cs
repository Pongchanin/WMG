using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4Controller : MonoBehaviour {

    public float moveSpeed;
    public int rotateSpeed;
    public Transform playerPoint;
    public GameObject GravityTrap;
    public GameObject Ball;
    public Transform firePoint;
    public bool PlayerFacingRight;
    public Rigidbody2D rigid2d;

    public float boostDelayTime = 0.5f;
    public float currentBoostDelayTime;
    public bool boosting = false;
    public float time;

    void Start()
    {
        currentBoostDelayTime = 0f;
        rigid2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "bullet3")
        {
            print("Collide");
            rigid2d.velocity = new Vector2(moveSpeed, 0);
            rigid2d.velocity = new Vector2(0, 0);
        }
        if (collision.collider.tag == "ball")
        {
            rigid2d.velocity = new Vector2(0, 0);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "bullet3")
        {
            print("Collide");
            rigid2d.velocity = new Vector2(0, 0);
        }
    }
    void Update()
    {

        if (Input.GetAxisRaw("Horizontal2") > 0.5f || Input.GetAxisRaw("Horizontal2") < -0.5f)
        {
            transform.Translate(0f, Input.GetAxisRaw("Horizontal2") * -moveSpeed * Time.deltaTime, 0f, Space.World);
        }
        if (Input.GetAxisRaw("Vertical2") > 0.5f || Input.GetAxisRaw("Vertical2") < -0.5f)
        {
            transform.Translate(Input.GetAxisRaw("Vertical2") * moveSpeed * Time.deltaTime, 0f, 0f, Space.World);
        }
        if (Input.GetAxisRaw("Rotate_P2") > 0.5f || Input.GetAxisRaw("Rotate_P2") < -0.5f || Input.GetButton("Rotate_P2"))
        {
            transform.Rotate(0f, 0f, Input.GetAxisRaw("Rotate_P2") * rotateSpeed * moveSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Fire2"))
        {
            Instantiate(Ball, firePoint.position, firePoint.rotation);
        }
        if (Input.GetKeyDown(KeyCode.L) && !boosting && Time.time > currentBoostDelayTime)
        {
            Instantiate(GravityTrap, playerPoint.position, playerPoint.rotation);
        }
    }
}
