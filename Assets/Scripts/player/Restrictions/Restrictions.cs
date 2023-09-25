using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restrictions : MonoBehaviour
{
    public Attack attack;
    public Movement movement;
    public Animator animator;
    public float swordAttackRange;

    public Transform  swordHitbox;

    public void Start()
    {
        movement = GetComponentInParent<Movement>();
        attack = GetComponentInParent<Attack>();
        animator = GetComponent<Animator>();

    }


    public void swordslashone()
    {
        movement.attackrestriction = true;
        if(movement.transform.localScale.x < 1f)
        movement.yeet.velocity = new Vector2(-4f, -0.5f);
        else movement.yeet.velocity = new Vector2(4f,-0.5f);
        movement.yeet.gravityScale = 0;

    }

    public void swordstop()
    {
        movement.yeet.velocity = new Vector2(0, 0);
    }
    public void swordslashtwo()
    {
        
        if (attack.attackQueuedUp == false)
        {
            animator.SetTrigger("stopattack");
            attack.inComboAttack = false;
            resetweaponrestriction();
           // animator.ResetTrigger("stopattack");

        }
        else
        {
            if (movement.transform.localScale.x < 1f)
                movement.yeet.velocity = new Vector2(-2f, 2);
            else movement.yeet.velocity = new Vector2(2f, 2);

          

            attack.attackQueuedUp = false;
        }

        movement.yeet.gravityScale = 0.5f;


    }
    public void swordslashthree()
    {
        animator.ResetTrigger("stopattack");
        if (attack.attackQueuedUp == false)
        {

            animator.SetTrigger("stopattack");
            attack.inComboAttack = false;
            resetweaponrestriction();
          

        } else
        {
            movement.attackrestrictionwithgravity = true;
            movement.yeet.velocity = new Vector2(0f, -2f);
            attack.attackQueuedUp = false;
        }


       

    }

    public void Damageenemies()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swordHitbox.position, swordAttackRange);
        foreach(Collider2D enemy in hitEnemies)
        {
                if(enemy.GetComponent<Enemyhealth>() != null)
            {
                enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage);
                if (enemy.GetComponent<Moveenemy>() != null)
                {
                    bool left = false;
                    if (movement.transform.localScale.x < 1f) left = true;
                    enemy.GetComponent<Moveenemy>().Knockbackafterattack(1, 1, left);
                }
                    Debug.Log("hit enemy");
            }
        }
    }
    public void changetonormal()
    {
        animator.SetTrigger("stopattack");
    }

    public void resetweaponrestriction()
    {

        movement.attackrestriction = false;
        movement.attackrestrictionwithgravity = false;
        attack.inComboAttack = false;
        attack.attackQueuedUp = false;
        
    }
}
