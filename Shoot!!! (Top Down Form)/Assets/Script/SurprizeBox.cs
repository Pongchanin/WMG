using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurprizeBox : MonoBehaviour {

    public GameObject surprizeBox;
    public Transform surprizeBoxFirePoint;
    public int shotDelay;

    public GameObject[] weapon;
    int weaponRandomed;
    public int bulletSpeed;
    Rigidbody2D[] rigidbody2Ds;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player3" || collision.gameObject.tag == "Player4")
        {
            print("Collide");
            print("Collide");
           weaponRandomed = Random.Range(0, weapon.Length);
           weapon[weaponRandomed].SetActive(true);
           Invoke("delayBoxShot", shotDelay);
          // Destroy(surprizeBox);
        }
    }

    void delayBoxShot()
    {
        Instantiate(weapon[weaponRandomed], surprizeBoxFirePoint.position, surprizeBoxFirePoint.rotation);
        
    }

    // Use this for initialization
    void Start () {
        surprizeBox = GameObject.Find("Surprize Box");
        surprizeBoxFirePoint = surprizeBox.gameObject.GetComponent<Transform>();
       for(int i = 0;i < weapon.Length; i++)
        {
            rigidbody2Ds[i] = weapon[i].GetComponent<Rigidbody2D>();
            weapon[i].SetActive(false);
        }
        
	}
	
	// Update is called once per frame
	void Update () {

        rigidbody2Ds[weaponRandomed].velocity = new Vector3(bulletSpeed, 0f, 0f);

    }
}
