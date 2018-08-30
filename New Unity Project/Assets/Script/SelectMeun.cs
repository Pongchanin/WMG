using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMeun : MonoBehaviour {

	public Button HardHardLevel;
	public Button EasyEasyLevel;

	void Start () 
	{
		HardHardLevel = HardHardLevel.GetComponent<Button> ();
		EasyEasyLevel = EasyEasyLevel.GetComponent<Button> ();

	}

	public void ExitPress()
	{
		HardHardLevel.enabled = false;
		EasyEasyLevel.enabled = false;
	}

	public void NoPress()
	{
		HardHardLevel.enabled = true;
		EasyEasyLevel.enabled = true;
	}

	public void EasyLevel()
	{
		Application.LoadLevel (3);
	}

	public void HardLevel()
	{
		Application.LoadLevel (4);
	}

	void Update () 
	{

	}
}

