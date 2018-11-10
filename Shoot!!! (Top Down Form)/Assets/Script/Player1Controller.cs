using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{

    public bool isShield;
    public float moveSpeed;
    public int rotateSpeed;
    public Transform firePoint;
    public GameObject Ball;
    public bool PlayerFacingRight;
    public GameObject Shield;
    public Transform playerPoint;

    public float boostDelayTime = 0.5f;
    public float currentBoostDelayTime;
    public bool boosting = false;
    public float time;

    Quaternion initRotation;

    public Animator anim;

    float timeRemaining = 3f;

    void Start()
    {
        currentBoostDelayTime = 0f;
      }
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(0f, Input.GetAxisRaw("Horizontal") * -moveSpeed * Time.deltaTime, 0f,Space.World);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime,0f , 0f,Space.World);
        }
        if (Input.GetAxisRaw("Rotate_P1")>0.5f || Input.GetAxisRaw("Rotate_P1") < -0.5f)
        {
            transform.Rotate(0f, 0f, Input.GetAxisRaw("Rotate_P1") * rotateSpeed * moveSpeed * Time.deltaTime,Space.Self);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Ball, firePoint.position, firePoint.rotation);
        }
        if(isShield == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && !boosting && Time.time > currentBoostDelayTime)
            {
                Instantiate(Shield, playerPoint.position, playerPoint.rotation);
                isShield = true;
                currentBoostDelayTime = Time.time + boostDelayTime;
            }
            isShield = false;
        }
    }

}