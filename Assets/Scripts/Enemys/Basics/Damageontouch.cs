using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageontouch : MonoBehaviour
{
    public int damage;
    public bool isHazard;

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) { Debug.Log("playergotdamaged");  collision.GetComponent<Playerhealth>().takedamage(damage);    }
        if (collision.GetComponent<Enemyhealth>())
        {
            collision.GetComponent<Enemyhealth>().dealdamage(10000, true, true);
        }
    }
}
