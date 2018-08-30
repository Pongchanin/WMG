using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2 +50,100,40),"Menu"))
		{
			Application.LoadLevel(0);
		}
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2 +100,100,40),"Retry"))
		{
			Application.LoadLevel(2);
		}
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2 +150,100,40),"Quit"))
		{
			Application.Quit();
		}
	}
}
