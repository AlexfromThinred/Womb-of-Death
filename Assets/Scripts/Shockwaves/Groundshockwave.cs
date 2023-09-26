using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundshockwave : MonoBehaviour
{

    public Transform left;
    public Transform right;
    public void dealdamageleft()
    {
        Collider2D[] hitEnemiesleft = Physics2D.OverlapBoxAll(left.position, new Vector2(1.3f, 0.5f), 0);
        foreach (Collider2D enemy in hitEnemiesleft)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)

                enemy.GetComponent<Enemyhealth>().dealdamage(2);

        }

        Collider2D[] hitEnemiesright = Physics2D.OverlapBoxAll(right.position, new Vector2(1.3f, 0.5f), 0);
        foreach (Collider2D enemy in hitEnemiesright)
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
        Gizmos.DrawCube(left.position, new Vector3(1.3f, 0.5f, 0));
     
    }
}
