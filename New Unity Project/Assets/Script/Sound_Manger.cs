using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manger : MonoBehaviour {


	public static Sound_Manger instance;
	public AudioClip[] soundList;
	public AudioSource audio;

	void Awake () 
	{
		instance = this;
		audio = gameObject.GetComponent< AudioSource > ();
	}

	void Start () 
	{

	}

	public void PlaySound(int soundIndex)
	{
		audio.PlayOneShot ( soundList [soundIndex]);
	}

	void Update () {
		
	}
}
