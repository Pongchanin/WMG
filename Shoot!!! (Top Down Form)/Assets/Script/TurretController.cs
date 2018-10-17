using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class TurretController : MonoBehaviour {


    public Player3Controller player;
    public GameObject TurretBullet;
    public Transform TurretFirePoint;

    public float bulletShotDelay;

    void delayBulletShot()
    {
        Instantiate(TurretBullet, TurretFirePoint.position, TurretFirePoint.rotation);

    }
    private void Awake()
    {
        InvokeRepeating("delayBulletShot", 0f, bulletShotDelay);
    }

    void Start()
    {
        GameObject Player = GameObject.Find("Player3");
        player = Player.GetComponent<Player3Controller>();
      //  currentBoostTime = 0f;
     //   currentBoostDelayTime = 0f;
    }

    void Update()
    {
        //Shoot Turrent Bullet
        // rigid2D.velocity = new Vector3(turretSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player3")
        {
            Destroy(other.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "bullet")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "bullet2")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "bullet4")
        {
            Destroy(this.gameObject);
        }
    }
}
