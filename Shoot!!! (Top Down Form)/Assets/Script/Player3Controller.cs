using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Controller : MonoBehaviour
{
    public bool isShot;

    public float moveSpeed;
    public Transform firePoint;
    public GameObject Ball;
    public bool PlayerFacingRight;
    public GameObject turret;
    public Transform turretPoint;

    public float boostDelayTime = 0.5f;
    public float currentBoostDelayTime;
    public bool boosting = false;
    public float time;

    void Start()
    {
        currentBoostDelayTime = 0f;
    }


    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Ball, firePoint.position, firePoint.rotation);
        }
        if (isShot == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && !boosting && Time.time > currentBoostDelayTime)
            {
                Instantiate(turret, turretPoint.position, turretPoint.rotation);
                currentBoostDelayTime = Time.time + boostDelayTime;
            }
        }

    }
}
