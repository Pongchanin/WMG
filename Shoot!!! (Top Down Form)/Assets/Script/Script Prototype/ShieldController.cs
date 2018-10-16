using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {

    public GameObject Shield;
    float timeRemaining = 3f;
    public GameObject player;
   // public Transform playerPos;

    void Start ()
    {
        player = GameObject.Find("Player1");
       // playerPos = player.GetComponent<Transform>();
	}
	

	void Update ()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            Destroy(Shield);
        }
        gameObject.transform.position = (new Vector3(player.transform.position.x, player.transform.position.y, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "bullet2")
        {
            Destroy(this.gameObject);
        }
        else if (collision.collider.tag == "ball")
        {
            Destroy(this.gameObject);
        }
    }
}
