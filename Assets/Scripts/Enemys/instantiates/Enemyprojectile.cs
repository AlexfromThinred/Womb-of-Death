using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyprojectile : MonoBehaviour
{
    public int projectilehealth;

    public void takedamage()
    {
        projectilehealth--;

        if(projectilehealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        takedamage();
    }
}
