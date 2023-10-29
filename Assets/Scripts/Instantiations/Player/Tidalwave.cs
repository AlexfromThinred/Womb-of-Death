using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tidalwave : MonoBehaviour
{
   
    public bool left;
    public Transform Wave;
    public Rigidbody2D rigid;
    public bool isFireInstead;
    public bool isAirDrill;
    public bool dosentMove;

    void Start()
    {
       
        if (left)
        {
            transform.localScale = new Vector2(-3, 3);
        }
    }
    public void FixedUpdate()
    {
        if (dosentMove) return;
        if (isFireInstead)
        {
            if (left)
            {
                rigid.velocity = new Vector2(-2, 0);
            }
            else rigid.velocity = new Vector2(2, 0);
        }
        else if (isAirDrill) {
            if (left)
            {
                rigid.velocity = new Vector2(-7, 0);
            }
            else rigid.velocity = new Vector2(7, 0);
        }else
        { 
            if (left)
            {
                rigid.velocity = new Vector2(-8, 0);
            }
            else rigid.velocity = new Vector2(8, 0);
        }
       

    }

    public void Firedamage()
    {
        if (dosentMove)
        {
            Collider2D[] hitEnemiesleft = Physics2D.OverlapBoxAll(Wave.position, new Vector2(1.6f, 1.6f), 0);
            foreach (Collider2D enemy in hitEnemiesleft)
            {
                if (enemy.GetComponent<Enemyhealth>() != null)

                    enemy.GetComponent<Enemyhealth>().dealdamage(3, true, false);

                if (enemy.GetComponent<Moveenemy>() != null)
                {
                    enemy.GetComponent<Moveenemy>().Knockbackafterattack(enemy.attachedRigidbody.velocity.x, 2f, left);

                }
            }
        } else
        {
            Collider2D[] hitEnemiesleft = Physics2D.OverlapBoxAll(Wave.position, new Vector2(0.6f, 1f), 0);
            foreach (Collider2D enemy in hitEnemiesleft)
            {
                if (enemy.GetComponent<Enemyhealth>() != null)

                    enemy.GetComponent<Enemyhealth>().dealdamage(1, true, false);

                if (enemy.GetComponent<Moveenemy>() != null)
                {
                    enemy.GetComponent<Moveenemy>().Knockbackafterattack(0.4f, 0.2f, left);

                }
            }
        }
       
    }

    public void Airdamage()
    {
        Collider2D[] hitEnemiesleft = Physics2D.OverlapBoxAll(Wave.position, new Vector2(0.8f, 0.6f), 0);
        foreach (Collider2D enemy in hitEnemiesleft)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)

                enemy.GetComponent<Enemyhealth>().dealdamage(1, false, false);

            if (enemy.GetComponent<Moveenemy>() != null)
            {
              //  enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.2f, 0.5f, left);

            }
        }
    }


    public void Tidalwavedamage()
    {
        Collider2D[] hitEnemiesleft = Physics2D.OverlapBoxAll(Wave.position, new Vector2(0.8f, 1f), 0);
        foreach (Collider2D enemy in hitEnemiesleft)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)

                enemy.GetComponent<Enemyhealth>().dealdamage(1, false, true);

            if (enemy.GetComponent<Moveenemy>() != null)
            {
                enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 0.3f, left);
                enemy.GetComponent<Moveenemy>().gettingfotzen();

            }
        }
    }

    public void destroytidal()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(Wave.position, new Vector3(1.6f, 1.6f, 0));

    }
}
