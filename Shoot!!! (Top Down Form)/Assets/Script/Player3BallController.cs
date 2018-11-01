using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3BallController : MonoBehaviour {

    Rigidbody2D rigid2D;
    public float speed;
    public Player3Controller player;


    void setBallDirection()
    {
        rigid2D.AddForce(player.gameObject.transform.up * speed);
        print(player.gameObject.transform.up);
    }

    void Start()
    {
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
        GameObject Player = GameObject.Find("Player3");
        player = Player.GetComponent<Player3Controller>();
        setBallDirection();
    }


    void Update()
    {

        // rigid2D.velocity = new Vector2(speed, 0);
        // rigid2D.angularVelocity = ratationSpeed;
        setBallDirection();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Player2")
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
        else if (collision.collider.tag == "bullet2")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "Player2")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "bullet4")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "Player4")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "Turret")
        {
            Destroy(this.gameObject);
        }
        else if(collision.collider.tag == "SBox")
        {
            Destroy(this.gameObject);
        }
    }
}
