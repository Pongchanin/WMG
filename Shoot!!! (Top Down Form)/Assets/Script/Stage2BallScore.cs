using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage2BallScore : MonoBehaviour
{

    //Player 3 Attribute
    GameObject player3;
    Transform playerSpawn3;
    Vector3 playerSpwn3Pos;
    Text player3_score;
    int p3_score = 0;

    //Player 4 Attribute
    GameObject player4;
    Transform playerSpwn4;
    Vector3 playerSpwn4Pos;
    Text player4_score;
    int p4_score = 0;

    //Big Ball Attribute
    GameObject ball;
    Rigidbody2D ballRigid2D;
    Transform ballSpwn;
    Vector3 ballSpwnPos;
    int ballSpeed;
    public int ballSpeedInit;

    void resetOnHit()
    {
        player3.SetActive(true);
        player3.transform.position = playerSpwn3Pos;
        player4.SetActive(true);
        player4.transform.position = playerSpwn4Pos;
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
        //Get Player 3 Component
        player3 = GameObject.FindGameObjectWithTag("Player3");
        player3_score = GameObject.Find("player3_score").GetComponent<Text>();
        playerSpawn3 = GameObject.Find("player3_spawnpoint").transform;
        playerSpwn3Pos = new Vector3(playerSpawn3.position.x, playerSpawn3.position.y, playerSpawn3.position.z);

        //Get Player 4 Component
        player4 = GameObject.FindGameObjectWithTag("Player4");
        player4_score = GameObject.Find("player4_score").GetComponent<Text>();
        playerSpwn4 = GameObject.Find("player4_spawnpoint").transform;
        playerSpwn4Pos = new Vector3(playerSpwn4.position.x, playerSpwn4.position.y, playerSpwn4.position.z);

        //Get Ball Component
        ball = GameObject.FindGameObjectWithTag("ball");
        ballSpwn = GameObject.Find("Ball_spawnpoint").transform;
        ballSpwnPos = new Vector3(ballSpwn.position.x, ballSpwn.position.y, ballSpwn.position.z);

        //Big Ball Component
        ballRigid2D = ball.gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player3" && p4_score == 4)
        {
            p4_score++;
            Destroy(col.gameObject);
            Time.timeScale = 0;
            Application.LoadLevel(5);
        }
        else if (col.gameObject.name == "Player3" && p4_score < 4)
        {

            player3.SetActive(false);
            player4.SetActive(false);
            ball.SetActive(false);
            resetOnHit();
            p4_score++;
        }
        if (col.gameObject.name == "Player4" && p3_score == 4)
        {
            p3_score++;
            Destroy(col.gameObject);
            Time.timeScale = 0;
            Application.LoadLevel(6);
        }
        else if (col.gameObject.name == "Player4" && p3_score < 4)
        {

            player3.SetActive(false);
            player4.SetActive(false);
            ball.SetActive(false);
            resetOnHit();
            p3_score++;
        }
        if (col.gameObject.CompareTag("bullet3"))
        {
            ballRigid2D.velocity = new Vector3(ballSpeed, 0.0f, 0.0f);
            increaseBallSpeed();
        }
        if (col.gameObject.CompareTag("bullet4"))
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
        player3_score.text = "Score: " + p3_score;
        player4_score.text = "Score: " + p4_score;
    }
}
