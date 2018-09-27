using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2BallController : MonoBehaviour {

    Rigidbody2D rigid2D;
    public float speed;
    public Player2Controller player;



    void setBallDirection()
    {
        if (player.PlayerFacingRight == true)
        {
            rigid2D.velocity = new Vector3(-speed, 0, 0);
        }
        else
        {
            rigid2D.velocity = new Vector3(speed, 0, 0);
        }
    }

    void Start()
    {
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
        GameObject Player = GameObject.Find("Player2");
        player = Player.GetComponent<Player2Controller>();

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
    }
}