using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletController : MonoBehaviour
{



    Rigidbody2D rigid2D;
    public float speed;
    public TurretController player;

    void Start ()
    {
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
        GameObject Player = GameObject.Find("Turret");
        player = Player.GetComponent<TurretController>();
    }
	

	void Update ()
    {
        rigid2D.velocity = new Vector3(speed, 0, 0);
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
        else if (collision.collider.tag == "bullet")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "bullet2")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "bullet3")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "bullet4")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "Player1")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "Player2")
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

    }
}
