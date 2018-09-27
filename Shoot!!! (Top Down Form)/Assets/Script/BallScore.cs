using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScore : MonoBehaviour
{

    //Player 1 Attribute
    GameObject player1;
    Transform playerSpawn1;
    Vector3 playerSpwnPos;
    Text player1_score;
    int p1_score = 0;
    GameObject p1_score_1;
    GameObject p1_score_2;
    GameObject p1_score_3;

    //Player 2 Attribute
    GameObject player2;
    Transform playerSpwn2;
    Vector3 playerSpwn2Pos;
    Text player2_score;
    int p2_score = 0;
    GameObject p2_score_1;
    GameObject p2_score_2;
    GameObject p2_score_3;

    //Big Ball Attribute
    GameObject ball;
    Transform ballSpwn;
    Vector3 ballSpwnPos;

    void resetOnHit()
    {
        player1.SetActive(true);
        player1.transform.position = playerSpwnPos;
        player2.SetActive(true);
        player2.transform.position = playerSpwn2Pos;
        ball.SetActive(true);
        ball.transform.position = ballSpwnPos;
       

    }

    private void Awake()
    {
        //Get Player 1 Component
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player1_score = GameObject.Find("player1_score").GetComponent<Text>();
        playerSpawn1 = GameObject.Find("player1_spawnpoint").transform;
        playerSpwnPos = new Vector3(playerSpawn1.position.x, playerSpawn1.position.y, playerSpawn1.position.z);
        p1_score_1 = GameObject.Find("p1_score01_get");
        p1_score_2 = GameObject.Find("p1_score02_get");
        p1_score_3 = GameObject.Find("p1_score03_get");


        //Get Player 2 Component
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player2_score = GameObject.Find("player2_score").GetComponent<Text>();
        playerSpwn2 = GameObject.Find("player2_spawnpoint").transform;
        playerSpwn2Pos = new Vector3(playerSpwn2.position.x, playerSpwn2.position.y, playerSpwn2.position.z);
        p2_score_1 = GameObject.Find("p2_score01_get");
        p2_score_2 = GameObject.Find("p2_score02_get");
        p2_score_3 = GameObject.Find("p2_score03_get");

        //Get Ball Component
        ball = GameObject.FindGameObjectWithTag("ball");
        ballSpwn = GameObject.Find("Ball_spawnpoint").transform;
        ballSpwnPos = new Vector3(ballSpwn.position.x, ballSpwn.position.y, ballSpwn.position.z);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player1" && p2_score == 2)
        {
            p2_score++;
            Destroy(col.gameObject);
            Time.timeScale = 0;
            Application.LoadLevel(3);
        }
        else if (col.gameObject.name == "Player1" && p2_score < 2)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            ball.SetActive(false);
            resetOnHit();
            p2_score++;
            if(p2_score == 1)
            {
                p2_score_1.SetActive(true);
            }
            else if(p2_score == 2)
            {
                p2_score_1.SetActive(true);
                p2_score_2.SetActive(true);
            }
            else if (p2_score == 3)
            {
               
                p2_score_3.SetActive(true);
            }
        }
        if (col.gameObject.name == "Player2" && p1_score == 2)
        {
            p1_score++;
            Destroy(col.gameObject);
            Time.timeScale = 0;
            Application.LoadLevel(2);
        }
        else if (col.gameObject.name == "Player2" && p1_score < 2)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            ball.SetActive(false);
            resetOnHit();
            p1_score++;
            if (p1_score == 1)
            {
                p1_score_1.SetActive(true);
            }
            else if (p1_score == 2)
            {
                p1_score_1.SetActive(true);
                p1_score_2.SetActive(true);
            }
            else if (p1_score == 3)
            {
                p1_score_3.SetActive(true);
            }
        }

    }

    // Use this for initialization
    void Start()
    {
        p2_score_1.SetActive(false);
        p2_score_2.SetActive(false);
        p2_score_3.SetActive(false);
        p1_score_1.SetActive(false);
        p1_score_2.SetActive(false);
        p1_score_3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        player1_score.text = "Score: " + p1_score;
        player2_score.text = "Score: " + p2_score;
    }
}
