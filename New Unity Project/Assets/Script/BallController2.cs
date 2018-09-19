using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController2 : MonoBehaviour {

    Rigidbody2D rigid2D;
    public float speed;
    public Movement_C1 player;
    public float ratationSpeed;

    public PLayer2Movement plaYer2;

    void setBallDirection()
    {
        if (plaYer2.playerFacingLeft == true)
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
        plaYer2 = gameObject.GetComponent<PLayer2Movement>();
    }


    void Update()
    {
        rigid2D.velocity = new Vector2(-speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "wall")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "plaYer2")
        {
            Destroy(this.gameObject);
        }
        else if(collision.collider.tag == "ball")
        {
            Destroy(this.gameObject);
        }
    }
}
