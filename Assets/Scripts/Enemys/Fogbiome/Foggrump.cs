using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foggrump : MonoBehaviour
{
    public int ran;
    public Animator anim;
    public Moveenemy move;
    public GameObject proj;
    public float timegone;

    public Transform Arm;
    public Transform tongue;
   

    public void Awake()
    {
       
      

    }

    [System.Obsolete]
    public void FixedUpdate()
    {
        if(move.frozen == true)
        {
            anim.SetTrigger("stop");
        }
        


        if (move.noticedPlayer == true && move.frozen == false)
        {


            timegone += Time.deltaTime;

            if (timegone >= 5)
            {
                attacks();
                timegone = 0;
            }
        }
    }


    




    [System.Obsolete]
    public void attacks()
    {
        GetComponent<ThrowStuff>().Throwprojectile(proj);
        ran = Random.RandomRange(0, 2);
        if(ran== 0)
        {
            anim.SetTrigger("Tongue");
        }
        else anim.SetTrigger("Arm");

    }

    public void movementIsZero()
    {
        move.dosentMove = true;
    }
    public void MovesNormal()
    {
        move.dosentMove = false;
    }
    public void Damageplayerarm()
    {
       


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Arm.position, 0.6f);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Playerhealth>() != null)
            {
                enemy.GetComponent<Playerhealth>().takedamage(6);
            }
        }
    }

    public void stopattacks()
    {
        anim.SetTrigger("stop");
    }
    public void Damageplayertongue()
    {
        


        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(tongue.position, new Vector3(2.3f, 0.6f, 3),0);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Playerhealth>() != null)
            {
                enemy.GetComponent<Playerhealth>().takedamage(3);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Arm.position, 0.6f);
        Gizmos.DrawCube(tongue.position, new Vector3(2.3f,0.6f,3));
    }
}
