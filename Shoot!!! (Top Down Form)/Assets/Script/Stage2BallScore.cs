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
    Quaternion playerSpwn3Rot;
    Text player3_score;
    int p3_score = 0;

    //Player 4 Attribute
    GameObject player4;
    Transform playerSpwn4;
    Vector3 playerSpwn4Pos;
    Quaternion playerSpwn4Rot;
    Text player4_score;
    int p4_score = 0;

    //Big Ball Attribute
    GameObject ball;
    Rigidbody2D ballRigid2D;
    Transform ballSpwn;
    Vector3 ballSpwnPos;
    int ballSpeed;
    public int ballSpeedInit;
    public Animator ballAnim;

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
        bullet = GameObject.FindGameObjectsWithTag("bullet3");
        bullet2 = GameObject.FindGameObjectsWithTag("bullet4");

        player3.SetActive(true);
        player3.transform.position = playerSpwn3Pos;
        player3.transform.localRotation = playerSpwn3Rot;
        player4.SetActive(true);
        player4.transform.position = playerSpwn4Pos;
        player4.transform.localRotation = playerSpwn4Rot;
        ball.SetActive(true);
        ball.transform.position = ballSpwnPos;
        ballSpeed = ballSpeedInit;

        for (int i = 0; i < bullet.Length; i++)
        {
            Destroy(bullet[i]);
        }

        for (int i = 0; i < bullet2.Length; i++)
        {
            Destroy(bullet2[i]);
        }
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
        playerSpwn3Rot = GameObject.Find("Player3").transform.localRotation;

        //Get Player 4 Component
        player4 = GameObject.FindGameObjectWithTag("Player4");
        player4_score = GameObject.Find("player4_score").GetComponent<Text>();
        playerSpwn4 = GameObject.Find("player4_spawnpoint").transform;
        playerSpwn4Pos = new Vector3(playerSpwn4.position.x, playerSpwn4.position.y, playerSpwn4.position.z);
        playerSpwn4Rot = GameObject.Find("Player4").transform.localRotation;

        //Get Ball Component
        ball = GameObject.FindGameObjectWithTag("ball");
        ballSpwn = GameObject.Find("Ball_spawnpoint").transform;
        ballSpwnPos = new Vector3(ballSpwn.position.x, ballSpwn.position.y, ballSpwn.position.z);
        ballAnim = gameObject.GetComponent<Animator>();

        //Big Ball Component
        ballRigid2D = ball.gameObject.GetComponent<Rigidbody2D>();
    }
    void ScoreUI_Updater()
    {
        if (p3_score == 1)
        {
            p1_score1.SetActive(true);
        }
        if (p3_score == 2)
        {
            p1_score2.SetActive(true);
        }
        if (p3_score == 3)
        {
            p1_score3.SetActive(true);
        }
        if (p4_score == 1)
        {
            p2_score3.SetActive(true);
        }
        if (p4_score == 2)
        {
            p2_score2.SetActive(true);
        }
        if (p4_score == 3)
        {
            p2_score1.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player3" && p4_score == 2)
        {
            p4_score++;
            Destroy(col.gameObject);
            Time.timeScale = 0;
            Application.LoadLevel(6);
        }
        else if (col.gameObject.name == "Player3" && p4_score < 2)
        {

            player3.SetActive(false);
            player4.SetActive(false);
            ball.SetActive(false);
            resetOnHit();
            p4_score++;
        }
        if (col.gameObject.name == "Player4" && p3_score == 2)
        {
            p3_score++;
            Destroy(col.gameObject);
            Time.timeScale = 0;
            Application.LoadLevel(5);
        }
        else if (col.gameObject.name == "Player4" && p3_score < 2)
        {

            player3.SetActive(false);
            player4.SetActive(false);
            ball.SetActive(false);
            resetOnHit();
            p3_score++;
        }
        if (col.gameObject.CompareTag("bullet3"))
        {

            //ballRigid2D.velocity = new Vector3(ballSpeed, 0.0f, 0.0f);
            increaseBallSpeed();
            ballAnim.SetBool("Green", true);
            ballAnim.SetBool("Red", false);
        }
        if (col.gameObject.CompareTag("bullet4"))
        {
           // ballRigid2D.velocity = new Vector3(-ballSpeed, 0.0f, 0.0f);
            increaseBallSpeed();
            ballAnim.SetBool("Red", true);
            ballAnim.SetBool("Green", false);
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

        ballSpeed = ballSpeedInit;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUI_Updater();
        player3_score.text = "Score: " + p3_score;
        player4_score.text = "Score: " + p4_score;
    }
}
