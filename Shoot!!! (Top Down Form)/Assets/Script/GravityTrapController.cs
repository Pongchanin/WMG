using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTrapController : MonoBehaviour
{
    public GameObject GravityTrap;
    float timeRemaining = 3f;
    Rigidbody2D rigid2D;
    public Player4Controller player;

    //Player 3 Component
    public Player3Controller player3;
    public int reduceSpeed;
    bool player3Contract;

    int playerSpeed;

	void Start ()
    {
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
        GameObject Player = GameObject.Find("Player4");
        player = Player.GetComponent<Player4Controller>();
        player3 = GameObject.Find("Player3").GetComponent<Player3Controller>();
        player3Contract = false;
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            Destroy(GravityTrap);
            player3.moveSpeed += reduceSpeed;
        }
        gameObject.transform.position = (new Vector3(player.transform.position.x, player.transform.position.y, 0));
        print("Player3 Speed: " + player3.moveSpeed);

    }

    void decreasePlayerSpeed()
    {
        //Player 3 Speed -= DecreaseSpeedValue

       player3.moveSpeed -= reduceSpeed;
        print("Player3 Speed: " + player3.moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.collider.tag == "Player3" && player3Contract == false)
        {
            decreasePlayerSpeed();
            player3Contract = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player3" && player3Contract == true)
        {
            player3Contract = false;
        }
    }
}
