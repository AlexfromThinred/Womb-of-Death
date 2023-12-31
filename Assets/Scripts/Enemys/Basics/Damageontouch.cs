using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageontouch : MonoBehaviour
{
    public int damage;
    public bool isHazard;
    public bool alsoattacksenemys;

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
            collision.GetComponent<Enemyhealth>().dealdamage(1000, true, true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (alsoattacksenemys)
        {
           
                if (collision.GetComponent<Enemyhealth>())
                {
                    collision.GetComponent<Enemyhealth>().dealdamage(damage, true, true);
                }
            
        }
    }
}
