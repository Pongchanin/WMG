using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallScore : MonoBehaviour
{

    //Player 1 Attribute
    GameObject player1;
    Transform playerSpawn1;
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
    Rigidbody2D ballRigid2D;
    Transform ballSpwn;
    Vector3 ballSpwnPos;
    int ballSpeed;
    public int ballSpeedInit;

    void resetOnHit()
    {
        player1.SetActive(true);
        player1.transform.position = playerSpwnPos;
        player2.SetActive(true);
        player2.transform.position = playerSpwn2Pos;
        ball.SetActive(true);
        ball.transform.position = ballSpwnPos;
        ballSpeed = ballSpeedInit;
        

    }
    void increaseBallSpeed()
    {
        ballSpeed += 1;
    }

    private void Awake()
    {
        //Get Player 1 Component
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player1_score = GameObject.Find("player1_score").GetComponent<Text>();
        playerSpawn1 = GameObject.Find("player1_spawnpoint").transform;
        playerSpwnPos = new Vector3(playerSpawn1.position.x, playerSpawn1.position.y, playerSpawn1.position.z);

        //Get Player 2 Component
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player2_score = GameObject.Find("player2_score").GetComponent<Text>();
        playerSpwn2 = GameObject.Find("player2_spawnpoint").transform;
        playerSpwn2Pos = new Vector3(playerSpwn2.position.x, playerSpwn2.position.y, playerSpwn2.position.z);

        //Get Ball Component
        ball = GameObject.FindGameObjectWithTag("ball");
        ballSpwn = GameObject.Find("Ball_spawnpoint").transform;
        ballSpwnPos = new Vector3(ballSpwn.position.x, ballSpwn.position.y, ballSpwn.position.z);

        //Big Ball Component
        ballRigid2D = ball.gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player1" && p2_score == 4)
        {
            p2_score++;
            Destroy(col.gameObject);
            Time.timeScale = 0;
            Application.LoadLevel(3);
        }
        else if (col.gameObject.name == "Player1" && p2_score < 4)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            ball.SetActive(false);
            resetOnHit();
            p2_score++;
        }
        if (col.gameObject.name == "Player2" && p1_score == 4)
        {
            p1_score++;
            Destroy(col.gameObject);
            Time.timeScale = 0;
            Application.LoadLevel(2);
        }
        else if (col.gameObject.name == "Player2" && p1_score < 4)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            ball.SetActive(false);
            resetOnHit();
            p1_score++;
        }
        if (col.gameObject.CompareTag("bullet"))
        {
            ballRigid2D.velocity = new Vector3(ballSpeed, 0.0f, 0.0f);
            increaseBallSpeed();
        }
        if (col.gameObject.CompareTag("bullet2"))
        {
            ballRigid2D.velocity = new Vector3(-ballSpeed, 0.0f, 0.0f);
            increaseBallSpeed();
        }

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player1_score.text = "Score: " + p1_score;
        player2_score.text = "Score: " + p2_score;
    }
}
    