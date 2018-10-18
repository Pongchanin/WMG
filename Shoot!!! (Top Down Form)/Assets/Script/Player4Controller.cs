using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4Controller : MonoBehaviour {

    public float moveSpeed;
    public Transform playerPoint;
    public GameObject GravityTrap;
    public GameObject Ball;
    public Transform firePoint;
    public bool PlayerFacingRight;

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

        if (Input.GetAxisRaw("Horizontal2") > 0.5f || Input.GetAxisRaw("Horizontal2") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal2") * moveSpeed * Time.deltaTime, 0f, 0f));
        }
        if (Input.GetAxisRaw("Vertical2") > 0.5f || Input.GetAxisRaw("Vertical2") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical2") * moveSpeed * Time.deltaTime, 0f));
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(Ball, firePoint.position, firePoint.rotation);
        }
        if (Input.GetKeyDown(KeyCode.L) && !boosting && Time.time > currentBoostDelayTime)
        {
            Instantiate(GravityTrap, playerPoint.position, playerPoint.rotation);
        }
    }
}
