using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour 
{
	float timeRemaining = 60f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeRemaining -= Time.deltaTime;
		if( timeRemaining <= 0)
		{
			SceneManager.LoadScene ("WinScene");
		}
	}
	void OnGUI()
	{
		if (timeRemaining > 0) {
			GUI.Box (new Rect (0, 30, 100, 25), "TIME : " +(int)timeRemaining);
		} 
	}
}
