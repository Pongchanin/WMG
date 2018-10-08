using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meun : MonoBehaviour {

	public Canvas startMenu;
	public Button startText;
	public Button exitText;

	void Start () 
	{
        startMenu = startMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
        startMenu.enabled = false;
	}

	public void ExitPress()
	{
        startMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress()
	{
        startMenu.enabled = false;
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
