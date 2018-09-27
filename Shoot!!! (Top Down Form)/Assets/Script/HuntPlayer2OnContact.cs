using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntPlayer2OnContact : MonoBehaviour {

    public int damgeToGive;

    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player2")
        {
            //  HealthManager.HurtPlayer(damgeToGive);
        }
    }
}

