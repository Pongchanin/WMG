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
    Vector3 playerSpwn1Pos;
    Quaternion playerSpwn1Rot;
    Text player1_score;
    int p1_score = 0;

    //Player 2 Attribute
    GameObject player2;
    Transform playerSpwn2;
    Vector3 playerSpwn2Pos;
    Quaternion playerSpwn2Rot;
    Text player2_score;
    int p2_score = 0;

    //Big Ball Attribute
    GameObject ball;
    Rigidbody2D ballRigid2D;
    Transform ballSpwn;
    Vector3 ballSpwnPos;
    int ballSpeed;
    public int ballSpeedInit;
    public Animator ballAnim;
    string ballColor;

    //Bullet Attribute
    GameObject[] bullet;
    GameObject[] bullet2;

    //Game UI Attribute
    GameObject p1_score1;
    GameObject p1_score2;
    GameObject p1_score3;

    GameObject p2_score1;
    GameObject p2_score2;
    GameObject p2_score3;

    void resetOnHit()
    {
        ballSpeed = ballSpeedInit;
        bullet = GameObject.FindGameObjectsWithTag("Basic Bullet");
        bullet2 = GameObject.FindGameObjectsWithTag("bullet2");

        player1.SetActive(true);
        player1.transform.position = playerSpwn1Pos;
        player1.transform.rotation = playerSpwn1Rot;
        player2.SetActive(true);
        player2.transform.position = playerSpwn2Pos;
        player2.transform.rotation = playerSpwn2Rot;
        ball.SetActive(true);
        ball.transform.position = ballSpwnPos;
        ballSpeed = ballSpeedInit;
        
        for(int i =0; i < bullet.Length; i++)
        {
            Destroy(bullet[i]);
        }

        for(int i = 0; i < bullet2.Length;i++)
        {
            Destroy(bullet2[i]);
        }
    }
    void increaseBallSpeed()
    {
        ballSpeed += 1;
    }

    void ScoreUI_Updater()
    {
        if(p1_score == 1)
        {
            p1_score1.SetActive(true);
        }
        if (p1_score == 2)
        {
            p1_score2.SetActive(true);
        }
        if (p1_score == 3)
        {
            p1_score3.SetActive(true);
        }
        if (p2_score == 1)
        {
            p2_score1.SetActive(true);
        }
        if (p2_score == 2)
        {
            p2_score2.SetActive(true);
        }
        if (p2_score == 3)
        {
            p2_score3.SetActive(true);
        }
    }

    private void Awake()
    {
        //Get Player 1 Component
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player1_score = GameObject.Find("player1_score").GetComponent<Text>();
        playerSpawn1 = GameObject.Find("player1_spawnpoint").transform;
        playerSpwn1Pos = new Vector3(playerSpawn1.position.x, playerSpawn1.position.y, playerSpawn1.position.z);
        playerSpwn1Rot = GameObject.Find("Player1").transform.localRotation;

        //Get Player 2 Component
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player2_score = GameObject.Find("player2_score").GetComponent<Text>();
        playerSpwn2 = GameObject.Find("player2_spawnpoint").transform;
        playerSpwn2Pos = new Vector3(playerSpwn2.position.x, playerSpwn2.position.y, playerSpwn2.position.z);
        playerSpwn2Rot = GameObject.Find("Player2").transform.localRotation;

        //Get Ball Component
        ball = GameObject.FindGameObjectWithTag("ball");
        ballSpwn = GameObject.Find("Ball_spawnpoint").transform;
        ballSpwnPos = new Vector3(ballSpwn.position.x, ballSpwn.position.y, ballSpwn.position.z);

        //Big Ball Component
        ballRigid2D = ball.gameObject.GetComponent<Rigidbody2D>();
        ballAnim = ball.gameObject.GetComponent<Animator>();
        ballColor = "White";
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player1" && p2_score == 2 && ballColor == "Orange")
        {
            p2_score++;
            Destroy(col.gameObject);
            Time.timeScale = 0;
            Application.LoadLevel(4);
        }
        else if (col.gameObject.name == "Player1" && p2_score < 2 && ballColor == "Orange")
        {

            player1.SetActive(false);
            player2.SetActive(false);
            ball.SetActive(false);
            resetOnHit();
            p2_score++;
        }
        if (col.gameObject.name == "Player2" && p1_score == 2 && ballColor == "Black")
        {
            p1_score++;
            Destroy(col.gameObject);
            Time.timeScale = 0;
            Application.LoadLevel(3);
        }
        else if (col.gameObject.name == "Player2" && p1_score < 2 && ballColor == "Black")
        {

            player1.SetActive(false);
            player2.SetActive(false);
            ball.SetActive(false);
            resetOnHit();
            p1_score++;
        }
        if (col.gameObject.CompareTag("bullet"))
        {
            //ballRigid2D.velocity = new Vector3(ballSpeed, 0.0f, 0.0f);
            increaseBallSpeed();
        }
        else if (col.gameObject.CompareTag("bullet2"))
        {
           // ballRigid2D.velocity = new Vector3(-ballSpeed, 0.0f, 0.0f);
            increaseBallSpeed();
            ballColor = "Orange";
            ballAnim.SetBool("Black", false);
            ballAnim.SetBool("Orange", true);
        }
        if (col.gameObject.CompareTag("Basic Bullet"))
        {
           // ballRigid2D.velocity = new Vector3(ballSpeed, 0.0f, 0.0f);
            increaseBallSpeed();
            ballColor = "Black";
            ballAnim.SetBool("Black", true);
            ballAnim.SetBool("Orange", false);
        }

    }

    // Use this for initialization
    void Start()
    {
        p1_score1 = GameObject.Find("p1_score1");
        p1_score2 = GameObject.Find("p1_score2");
        p1_score3 = GameObject.Find("p1_score3");
        p2_score1 = GameObject.Find("p2_score1");
        p2_score2 = GameObject.Find("p2_score2");
        p2_score3 = GameObject.Find("p2_score3");

        p1_score1.SetActive(false);
        p1_score2.SetActive(false);
        p1_score3.SetActive(false);
        p2_score1.SetActive(false);
        p2_score2.SetActive(false);
        p2_score3.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUI_Updater();
        player1_score.text = "Score: " + p1_score;
        player2_score.text = "Score: " + p2_score;
    }
}
    