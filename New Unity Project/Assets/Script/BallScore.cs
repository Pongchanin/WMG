using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScore : MonoBehaviour {

    //Player 1 Attribute
    GameObject player;
    Transform playerSpwn;
    Vector3 playerSpwnPos;
    Text player1_score;
    int p1_score = 0;

    //Player 2 Attribute
    GameObject player2;
    Transform playerSpwn2;
    Vector3 playerSpwn2Pos;
    Text player2_score;
    int p2_score = 0;

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
        player1_score = GameObject.Find("player1_score").GetComponent<Text>();
        playerSpwn = GameObject.Find("player1_spawnpoint").transform;
        playerSpwnPos = new Vector3(playerSpwn.position.x, playerSpwn.position.y, playerSpwn.position.z);

        //Get Player 2 Component
        player2 = GameObject.FindGameObjectWithTag("plaYer2");
        player2_score = GameObject.Find("player2_score").GetComponent<Text>();
        playerSpwn2 = GameObject.Find("player2_spawnpoint").transform;
        playerSpwn2Pos = new Vector3(playerSpwn2.position.x, playerSpwn2.position.y, playerSpwn2.position.z);

        //Get Ball Component
        ball = GameObject.FindGameObjectWithTag("ball");
        ballSpwn = GameObject.Find("Ball_spawnpoint").transform;
        ballSpwnPos = new Vector3(ballSpwn.position.x, ballSpwn.position.y, ballSpwn.position.z);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player1" && p2_score == 8)
        {
            p2_score++;
            Destroy(col.gameObject);
            Time.timeScale = 0;
          
        }
        else if (col.gameObject.name == "Player1" && p2_score < 8)
        {

            player.SetActive(false);
            player2.SetActive(false);
            ball.SetActive(false);
            resetOnHit();
            p2_score++;
        }
        if (col.gameObject.name == "Player2" && p1_score == 8)
        {
            p1_score++;
            Destroy(col.gameObject);
            Time.timeScale = 0;
        }
        else if (col.gameObject.name == "Player2" && p1_score < 8)
        {

            player.SetActive(false);
            player2.SetActive(false);
            ball.SetActive(false);
            resetOnHit();
            p1_score++;
        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        player1_score.text = "Score: " + p1_score;
        player2_score.text = "Score: " + p2_score;
    }
}
