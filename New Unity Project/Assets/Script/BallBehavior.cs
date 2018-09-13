using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

    public int attackDamage = 10;

    //Player 1 Attribute
    GameObject player;
    PlayerHealth playerHealth;
    Transform playerSpwn;
    Vector3 playerSpwnPos;


    //Player 2 Attribute
    GameObject player2;
    Player2Health player2Health;
    Transform playerSpwn2;
    Vector3 playerSpwn2Pos;

    //Big Ball Attribute
    GameObject ball;
    Transform ballSpwn;
    Vector3 ballSpwnPos;

    void resetOnHit()
    {
        player.SetActive(true);
        player.transform.position = playerSpwnPos;
        player2.SetActive(true);
        player2.transform.position = playerSpwn2Pos;
        ball.SetActive(true);
        ball.transform.position = ballSpwnPos;

    }
    private void Awake()
    {
        //Get Player 1 Component
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerSpwn = GameObject.Find("player1_spawnpoint").transform;
        playerSpwnPos = new Vector3(playerSpwn.position.x, playerSpwn.position.y, playerSpwn.position.z);

        //Get Player 2 Component
        player2 = GameObject.FindGameObjectWithTag("plaYer2");
        player2Health = player2.GetComponent<Player2Health>();
        playerSpwn2 = GameObject.Find("player2_spawnpoint").transform;
        playerSpwn2Pos = new Vector3(playerSpwn2.position.x, playerSpwn2.position.y, playerSpwn2.position.z);

        //Get Ball Component
        ball = GameObject.FindGameObjectWithTag("ball");
        ballSpwn = GameObject.Find("Ball_spawnpoint").transform;
        ballSpwnPos = new Vector3(ballSpwn.position.x, ballSpwn.position.y, ballSpwn.position.z);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player1" && playerHealth.currentHealth < 10)
        {
            Destroy(col.gameObject);
            print("Health: " + playerHealth.currentHealth);
        }
        else if (col.gameObject.name == "Player1" && playerHealth.currentHealth > 0)
        {

            player.SetActive(false);
            player2.SetActive(false);
            ball.SetActive(false);
            print("Health: " + playerHealth.currentHealth);
            playerHealth.currentHealth -= 10;
            resetOnHit();

        }
        if (col.gameObject.name == "Player2" && player2Health.currentHP < 10)
        {
            Destroy(col.gameObject);
            print("Health: " + player2Health.currentHP);
        }
        else if (col.gameObject.name == "Player2" && player2Health.currentHP > 0)
        {

            player.SetActive(false);
            player2.SetActive(false);
            ball.SetActive(false);
            print("Health: " + player2Health.currentHP);
            player2Health.currentHP -= 10;
            resetOnHit();

        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
