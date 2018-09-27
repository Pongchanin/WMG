using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{

    public float moveSpeed;
    public Transform firePoint;
    public GameObject Ball;
    public bool PlayerFacingRight;

    void Start()
    {

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
    }

}