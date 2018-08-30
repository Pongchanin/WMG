using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour 
{


	void Start () 
	{

	}

	void Update () 
	{

	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width/1-110,Screen.height/2+570,100,40),"NEXT"))
		{
			Application.LoadLevel(2);
		}
	}
}

