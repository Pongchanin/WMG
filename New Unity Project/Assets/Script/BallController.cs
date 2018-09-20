using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float speed;
    public Movement_C1 player;
    public float ratationSpeed;



    void setBallDirection()
    {
        if (player.PlayerFacingRight == true)
        {
            rigid2D.velocity = new Vector2(speed, 0);
            rigid2D.angularVelocity = ratationSpeed;
        }
        else
        {
            rigid2D.velocity = new Vector2(-speed, 0);
            rigid2D.angularVelocity = ratationSpeed;
        }
    }

    void Start()
    {
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
        GameObject Player = GameObject.Find("Player1");
        player = Player.GetComponent<Movement_C1>();
       
    }


    void Update()
    {
        
       // rigid2D.velocity = new Vector2(speed, 0);
       // rigid2D.angularVelocity = ratationSpeed;
        setBallDirection();

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
        else if (collision.collider.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "ball")
        {
            Destroy(this.gameObject);
        }
    }
}
