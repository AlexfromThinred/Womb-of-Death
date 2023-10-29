using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageontouch : MonoBehaviour
{
    public int damage;
    public bool isHazard;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (collision.GetComponent<Playerhealth>() != null)
            {

                collision.GetComponent<Playerhealth>().takedamage(damage);
            }


        }
        if (collision.GetComponent<Enemyhealth>() && isHazard == true)
        {
            collision.GetComponent<Enemyhealth>().dealdamage(10000, true, true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        
    }
}
