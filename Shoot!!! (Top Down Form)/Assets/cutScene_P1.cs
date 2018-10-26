using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutScene_P1 : MonoBehaviour {
   public GameObject cutSceneP1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.E))
        {
            cutSceneP1.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            cutSceneP1.SetActive(false);
           // Time.timeScale = 1;
        }
	}
}
