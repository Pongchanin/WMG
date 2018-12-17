using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Controller : MonoBehaviour
{
    public bool isShot;

    public float moveSpeed;
    public int rotateSpeed;
    public Transform firePoint;
    public GameObject Ball;
    public bool PlayerFacingRight;
    public GameObject turret;
    public Transform turretPoint;
    public Rigidbody2D rigid2d;

    public float boostDelayTime = 0.5f;
    public float currentBoostDelayTime;
    public bool boosting = false;
    public float time;

    void Start()
    {
        rigid2d = gameObject.GetComponent<Rigidbody2D>();
        currentBoostDelayTime = 0f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "bullet4")
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


    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(0f, Input.GetAxisRaw("Horizontal") * -moveSpeed * Time.deltaTime, 0f, Space.World);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f, 0f, Space.World);
        }
        /*if (Input.GetAxisRaw("Rotate_P1") > 0.5f || Input.GetAxisRaw("Rotate_P1") < -0.5f)
        {
            transform.Rotate(0f, 0f, Input.GetAxisRaw("Rotate_P1") * rotateSpeed * moveSpeed * Time.deltaTime, Space.Self);
        }*/
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            Instantiate(Ball, firePoint.position, firePoint.rotation);
        }
        if (isShot == false)
        {
            if (Input.GetKeyDown(KeyCode.F) && !boosting && Time.time > currentBoostDelayTime)
            {
                Instantiate(turret, turretPoint.position, turretPoint.rotation);
                currentBoostDelayTime = Time.time + boostDelayTime;
            }
        }

    }
    private void FixedUpdate()
    {
        //Rotate Function Joy
        float defaultCharAngle = -90f;
        Quaternion rotChar;
        float rotX = Input.GetAxis("P1_rotX");
        float rotY = Input.GetAxis("P1_rotY");

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
