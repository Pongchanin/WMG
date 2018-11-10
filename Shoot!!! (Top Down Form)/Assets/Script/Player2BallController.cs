using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2BallController : MonoBehaviour {

    Rigidbody2D rigid2D;
    public float speed;
    public Player2Controller player;



    void setBallDirection()
    {
        rigid2D.AddForce(player.gameObject.transform.up * -speed);
        print(player.gameObject.transform.up);
    }

    void Start()
    {
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
        GameObject Player = GameObject.Find("Player2");
        player = Player.GetComponent<Player2Controller>();
        setBallDirection();

    }


    void Update()
    {

        // rigid2D.velocity = new Vector2(speed, 0);
        // rigid2D.angularVelocity = ratationSpeed;
     

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            Destroy(other.gameObject);
        }
      else if (other.tag == "Player2")
        {
            Destroy(other.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "Player1")
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
        else if (collision.collider.tag == "bullet")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "bullet3")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "Player3")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "Player4")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "bullet4")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "Basic Bullet")
        {
            Destroy(this.gameObject);
        }

    }
}