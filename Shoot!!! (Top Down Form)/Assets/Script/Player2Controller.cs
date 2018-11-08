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

    public Transform firePoint;
    public GameObject Ball;
    public bool PlayerFacingRight;

    void Start()
    {
        currentBoostTime = 0f;
        currentBoostDelayTime = 0f;
        speed = baseSpeed;
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
        if (Input.GetKeyDown(KeyCode.Return))
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
}