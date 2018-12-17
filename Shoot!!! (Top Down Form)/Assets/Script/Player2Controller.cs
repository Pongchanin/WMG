using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float boostTime = 2.0f;
    public float currentBoostTime;
    public float boostDelayTime = 0.5f;
    public float currentBoostDelayTime;
    public bool boosting = false;
    public float time;

    public float baseSpeed = 1.0f;
    public float speedBoost = 2.0f;
    public float speed;
    public int rotateSpeed;
    public Rigidbody2D rigid2d;

    public Transform firePoint;
    public GameObject Ball;
    public bool PlayerFacingRight;

    void Start()
    {
        currentBoostTime = 0f;
        currentBoostDelayTime = 0f;
        speed = baseSpeed;
        rigid2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Basic Bullet")
        {
            rigid2d.velocity = new Vector2(0, 0);
        }
        if(collision.collider.tag == "ball")
        {
            rigid2d.velocity = new Vector2(0, 0);
        }
    }
    void Update()
    {
        time = Time.time;
        movePlayer();

        if (Input.GetAxisRaw("Horizontal2") > 0.5f || Input.GetAxisRaw("Horizontal2") < -0.5f)
        {
            transform.Translate(0f, Input.GetAxisRaw("Horizontal2") * -speed * Time.deltaTime, 0f, Space.World);
        }
        if (Input.GetAxisRaw("Vertical2") > 0.5f || Input.GetAxisRaw("Vertical2") < -0.5f)
        {
            transform.Translate(Input.GetAxisRaw("Vertical2") * speed * Time.deltaTime, 0f, 0f, Space.World);
        }
        if (Input.GetAxisRaw("Rotate_P2") > 0.5f || Input.GetAxisRaw("Rotate_P2") < -0.5f)
        {
            transform.Rotate(0f, 0f, Input.GetAxisRaw("Rotate_P2") * rotateSpeed * speed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Fire2"))
        {
            Instantiate(Ball, firePoint.position, firePoint.rotation);
        }
        if (Input.GetKeyDown(KeyCode.L) && !boosting && Time.time > currentBoostDelayTime)
        {
            print("Speed Booster is working");
            currentBoostTime = Time.time + boostTime; 
            boosting = true;
            currentBoostDelayTime = Time.time + boostDelayTime;
        }
        if(Time.time > currentBoostDelayTime)
        {
            boosting = false;
        }

    }
    void movePlayer()
    {
        if (boosting)
        {
            speed = speedBoost;
        }

        if (!boosting)
        {
            speed = baseSpeed;
        }
    }

    private void FixedUpdate()
    {
        //Rotate Function Joy
        float defaultCharAngle = -90f;
        Quaternion rotChar;
        float rotX = Input.GetAxis("P2_rotX");
        float rotY = Input.GetAxis("P2_rotY");

        print("X: " + rotX + " Y: " + rotY);

        if (rotX == 0 && rotY == 0)
        {

            // float rotate = Mathf.Atan2(rotX,rotY) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0f, 0f, defaultCharAngle);
            this.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, (Mathf.Atan2(rotY, rotX) * Mathf.Rad2Deg) + defaultCharAngle), Time.deltaTime * 20);
        }
        else
        {
            Vector3 diffXY = new Vector3(rotX, rotY);
            // diffXY.Normalize();
            // float rotateChar = Mathf.Atan2(diffXY.y, diffXY.x) * Mathf.Rad2Deg;
            // transform.rotation = Quaternion.Euler(0f, 0f, rotateChar + defaultCharAngle);

            // Vector2 direction = rigid2d.transform.position - transform.position;
            this.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, (Mathf.Atan2(rotY, rotX) * Mathf.Rad2Deg) + defaultCharAngle), Time.deltaTime * 20);
        }


    }
}