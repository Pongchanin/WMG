using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Health : MonoBehaviour {

    public const int maxHP = 100;
    public int currentHP = maxHP;
   // public GameObject players;

    void Start()
    {
        print(currentHP);

    }
    void update()
    {

    }

    public void ResetHP()
    {
        currentHP = maxHP;
    }

    public void HurtPlayer(int damageToGive)
    {
        currentHP -= damageToGive;
        if (currentHP <= 0)
        {
            SceneManager.LoadScene("Endingsceen");
        }
    }

    void OnGUI()
    {
       // GUI.Box(new Rect(0, 0, 100, 25), "HEALTH" + " = " + (Mathf.Round(currentHP)));
    }
}
