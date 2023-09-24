using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageontouch : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) { GetComponent<Playerhealth>().takedamage(damage);    }
    }
}
