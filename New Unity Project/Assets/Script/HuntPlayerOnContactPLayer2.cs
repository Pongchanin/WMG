using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntPlayerOnContactPLayer2 : MonoBehaviour {

    public int damgeToGive;

    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "player2")
        {
            HealthManager.HurtPlayer(damgeToGive);
        }
    }
}
