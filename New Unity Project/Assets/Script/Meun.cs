using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meun : MonoBehaviour {

	public Canvas quitMeun;
	public Button startText;
	public Button exitText;

	void Start () 
	{
		quitMeun = quitMeun.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMeun.enabled = false;
	}

	public void ExitPress()
	{
		quitMeun.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress()
	{
		quitMeun.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void StartLevel()
	{
		Application.LoadLevel (1);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

	void Update () 
	{
		
	}
}
