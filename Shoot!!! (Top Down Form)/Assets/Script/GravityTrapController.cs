using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTrapController : MonoBehaviour
{
    public GameObject GravityTrap;
    float timeRemaining = 3f;
    public GameObject player;

    int playerSpeed;

	void Start ()
    {
        GameObject Player = GameObject.Find("Player4");
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            Destroy(GravityTrap);
        }
        gameObject.transform.position = (new Vector3(GravityTrap.transform.position.x, GravityTrap.transform.position.y, 0));
    }

    void decreasePlayerSpeed()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player3")
        {
            decreasePlayerSpeed();
        }
    }
}
