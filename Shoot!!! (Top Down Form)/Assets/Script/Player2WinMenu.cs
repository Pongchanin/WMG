using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2WinMenu : MonoBehaviour {


    void Start()
    {

    }

    void Update()
    {

    }
    public void ReturnToMenu()
    {
        Application.LoadLevel(2);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
