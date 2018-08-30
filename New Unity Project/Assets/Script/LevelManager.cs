using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject currentCheckpoint;

    private Movement_C1 player;

	void Start ()
    {
        player = FindObjectOfType<Movement_C1>();
	}
	

	void Update ()
    {
		
	}
    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
        player.transform.position = currentCheckpoint.transform.position;
    }

}
