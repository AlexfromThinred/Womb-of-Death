using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public int health;




    public void dealdamage(int damage)
    {
        Debug.Log("damagetakenawrfgvoahpfvuhjwasifuhwfgh");
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
