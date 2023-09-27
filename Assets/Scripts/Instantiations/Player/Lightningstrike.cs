using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightningstrike : MonoBehaviour
{
    public Transform midstrike;
    public void dealdamage()
    {
        Collider2D[] hitEnemiesleft = Physics2D.OverlapBoxAll(midstrike.position, new Vector2(0.4f, 3f), 0);
        foreach (Collider2D enemy in hitEnemiesleft)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)

                enemy.GetComponent<Enemyhealth>().dealdamage(2);

        }

       
    }



    public void destroygameobj()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(midstrike.position, new Vector3(0.4f,3f, 0));

    }
}
