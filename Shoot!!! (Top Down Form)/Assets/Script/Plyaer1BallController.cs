using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plyaer1BallController : MonoBehaviour {

    Rigidbody2D rigid2D;
    public float speed;
    public Player1Controller player;



    void setBallDirection()
    {
        if (player.PlayerFacingRight == true)
        {
            rigid2D.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            rigid2D.velocity = new Vector3(-speed, 0, 0);
        }
    }

    void Start()
    {
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
        GameObject Player = GameObject.Find("Player1");
        player = Player.GetComponent<Player1Controller>();

    }


    void Update()
    {

        // rigid2D.velocity = new Vector2(speed, 0);
        // rigid2D.angularVelocity = ratationSpeed;
        setBallDirection();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
        else if (collision.collider.tag == "Player2")
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