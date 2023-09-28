using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthstabing : MonoBehaviour
{
    public Movement movement;
    public bool left;
    public void Start()
    {
        movement = FindObjectOfType<Movement>();
        if (movement.transform.localScale.x < 1f) left = true;
        if(left == true)
        {
            transform.localScale = new Vector2(-3, 3);
        }
    }
    public Transform stab;
  public void Earthstab()
    {
        Collider2D[] hitEnemiesleft = Physics2D.OverlapBoxAll(stab.position, new Vector2(0.8f, 1f), 0);
        foreach (Collider2D enemy in hitEnemiesleft)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)

                enemy.GetComponent<Enemyhealth>().dealdamage(2);

            if (enemy.GetComponent<Moveenemy>() != null)
            {



          
               
                   
                   
                        enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 5, left);

                }


            }


        }

    public void destroyearth()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(stab.position, new Vector3(0.8f, 1f, 0));

    }

}
