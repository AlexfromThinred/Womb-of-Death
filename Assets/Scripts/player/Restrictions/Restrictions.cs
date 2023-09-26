using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restrictions : MonoBehaviour
{
    public Attack attack;
    public Movement movement;
    public Animator animator;
    public float swordAttackRange;
    public bool isupattack;
    public bool isdownattack;
    public bool isdownslashingendless;
    public Transform  swordHitbox;
    public bool reducedamagebyhalf;

    public void Start()
    {
        movement = GetComponentInParent<Movement>();
        attack = GetComponentInParent<Attack>();
        animator = GetComponent<Animator>();
        isupattack = false;
        isdownattack = false;
        isdownslashingendless = false;
    }

    public void sworduupslash()
    {
        isupattack = true;
        movement.yeet.velocity = new Vector2(0, 0);
        movement.attackrestriction = true;
       
    }
    public void sworduupslashmovement()
    {
        movement.yeet.gravityScale = 0;
        movement.yeet.velocity = new Vector2(0, 10f);
        animator.ResetTrigger("swordattackup");
    }

    public void sworddownstart()
    {
    
        isdownattack = true;
        reducedamagebyhalf = true;
        movement.yeet.velocity = new Vector2(1, 2);
        movement.attackrestriction = true;

    }

    public void sworddownfall()
    {
        movement.yeet.velocity = new Vector2(0, -15);
        isdownslashingendless = true;
       
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
        isdownattack = true;
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
                if(reducedamagebyhalf == false)
                enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage);
                else enemy.GetComponent<Enemyhealth>().dealdamage(  attack.currentWeapon.damage / 2 );
                if (enemy.GetComponent<Moveenemy>() != null)
                {



                    bool left = false;
                    if (movement.transform.localScale.x < 1f) left = true;
                    if(isupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 4, left); else if( isdownattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(1, -6, left); else
                    enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 1, left);




                }
                    Debug.Log("hit enemy");
            }
        }
    }
    public void changetonormal()
    {
        attack.currentMeeleCooldown = attack.currentWeapon.cooldown;
        animator.SetTrigger("stopattack");
        isdownattack = false;
        reducedamagebyhalf = false;
       

    }

    public void downslashendsword()
    {
        isdownattack = false;
        reducedamagebyhalf = false;
        animator.ResetTrigger("reachedground");
    }

    public void resetweaponrestriction()
    {
     
        movement.yeet.gravityScale = 0.5f;
        movement.attackrestriction = false;
        movement.attackrestrictionwithgravity = false;
        attack.inComboAttack = false;
        attack.attackQueuedUp = false;
        
    }

    public void resetmovement()
    {
        movement.yeet.velocity = new Vector2(0, 0);
    }
    public void resetmovementafterswordup()
    {
        movement.yeet.velocity = new Vector2(0, 1);
        isupattack = false;
    }

    public void Update()
    {
        if(isdownslashingendless == true && movement.grounded == true)
        {
            animator.SetTrigger("reachedground");
        }
        if(movement.grounded == false)
        {
            animator.ResetTrigger("reachedground");
        }

    }
}
