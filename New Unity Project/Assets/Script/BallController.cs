using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float speed;
    public Movement_C1 player;
    public float ratationSpeed;


    void Start()
    {
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
        player = gameObject.GetComponent<Movement_C1>();
        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
            ratationSpeed = -ratationSpeed;
        }
        else if (player.transform.localScale.x > 0)
        {
            speed = speed;
            ratationSpeed = ratationSpeed;
        }
    }


    void Update()
    {
        rigid2D.velocity = new Vector2(speed, 0);
        rigid2D.angularVelocity = ratationSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "plaYer2")
        {
            Destroy (other.gameObject);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "wall")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "plaYer2")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "ball")
        {
            Destroy(this.gameObject);
        }
    }
}
