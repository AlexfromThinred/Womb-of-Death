using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restrictions : MonoBehaviour
{
    public Attack attack;
    public Movement movement;
    public Animator animator;
    public Memory memory;
    public float swordAttackRange;
    public bool isupattack, isONLYupattack;
    public bool isdownattack;
    public bool isdownslashingendless;
    public Transform swordHitbox;
    public Transform downslashhitbox;
    public Transform upslashhitbox;
    public Transform backslashhitbox;
    public bool reducedamagebyhalf;
    public bool boosteddown;
    public int downdamagecounter;
    public bool hasNOknockback;
    public bool trippledamage;



    public bool Hammerjumpdown;

    public GameObject shockWaveOnGround;
    public GameObject Lightningstrike;


    public void Start()
    {
        movement = GetComponentInParent<Movement>();
        attack = GetComponentInParent<Attack>();
        animator = GetComponent<Animator>();
        memory = GetComponentInParent<Memory>();
        isupattack = false;
        isdownattack = false;
        isdownslashingendless = false;
        trippledamage = false;
    }

    public void Update()
    {
        if (isdownslashingendless == true && movement.grounded == true)
        {
            animator.SetTrigger("reachedground");
        }
        if (movement.grounded == false)
        {
            animator.ResetTrigger("reachedground");
        }

       
    }

    #region singleattacks

    public void Hammerupstart()
    {
        reducedamagebyhalf = true;
        movement.yeet.velocity = new Vector2(0, 0);
        attack.currentMeeleCooldown = attack.currentWeapon.cooldown;
        movement.attackrestriction = true;
    }

    public void Hammerupjump()
    {
        reducedamagebyhalf = true;
        isONLYupattack = true;
        if (movement.transform.localScale.x < 1f)
            movement.yeet.velocity = new Vector2(-5f, 7f);
        else movement.yeet.velocity = new Vector2(5f, 7f);
    }

    public void Hammerupdown()
    {
        swordAttackRange = swordAttackRange + 0.7f;
        movement.yeet.velocity = new Vector2(0, -14);
        isdownslashingendless = true;
        boosteddown = true;
        downdamagecounter = 3;

    }
    public void Hammerfalling()
    {
        downdamagecounter ++;
        movement.yeet.velocity = new Vector2(0, -14);
    }

    public void Hammerupend()
    {
         reducedamagebyhalf = true;
        animator.ResetTrigger("reachedground");
        boosteddown = false;
        downdamagecounter = 0;
        isdownslashingendless = true;
        isONLYupattack = true;
    }

    public void sworduupslash()
    {
        isupattack = true;
        movement.yeet.velocity = new Vector2(0, 0);
        movement.attackrestriction = true;
        reducedamagebyhalf = true;

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
        boosteddown = true;


    }

    public void swordslashone()
    {
        swordAttackRange = swordAttackRange + 0.2f;
        reducedamagebyhalf = true;
        movement.attackrestriction = true;
        if (movement.transform.localScale.x < 1f)
            movement.yeet.velocity = new Vector2(-4f, -0.5f);
        else movement.yeet.velocity = new Vector2(4f, -0.5f);
        movement.yeet.gravityScale = 0;
        attack.currentMeeleCooldown = attack.currentWeapon.cooldown;
        Debug.Log(attack.currentWeapon.cooldown);
    }

    public void swordstop()
    {
        movement.yeet.velocity = new Vector2(0, 0);
    }

    public void swordslashtwo()
    {
        reducedamagebyhalf = false;
        if (attack.attackQueuedUp == false)
        {
            animator.SetTrigger("stopattack");
            attack.inComboAttack = false;
            resetweaponrestriction();
            attack.currentMeeleCooldown = attack.currentWeapon.cooldown;
            swordAttackRange = swordAttackRange - 0.2f;


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
            attack.currentMeeleCooldown = attack.currentWeapon.cooldown;
            swordAttackRange = swordAttackRange - 0.2f;


        }
        else
        {
            movement.attackrestrictionwithgravity = true;
            movement.yeet.velocity = new Vector2(0f, -2f);
            attack.attackQueuedUp = false;
        }




    }

   
    public void changetonormal()
    {

        animator.SetTrigger("stopattack");
        isdownattack = false;
        reducedamagebyhalf = false;
        attack.currentMeeleCooldown = attack.currentWeapon.cooldown;

        StartCoroutine(fixstuck());
    }

    public IEnumerator fixstuck()
    {

        yield return new WaitForSeconds(0.01f);
        animator.ResetTrigger("stopattack");
    }

    public void downslashendsword()
    {
        isdownattack = false;
        reducedamagebyhalf = false;
        animator.ResetTrigger("reachedground");
        boosteddown = false;
        downdamagecounter = 0;
    }

    public void resetweaponrestriction()
    {

        movement.yeet.gravityScale = 0.5f;
        movement.attackrestriction = false;
        movement.attackrestrictionwithgravity = false;
        attack.inComboAttack = false;
        attack.attackQueuedUp = false;
        reducedamagebyhalf = false;
        downdamagecounter = 0;
    }

    public void resetmovement()
    {
        movement.yeet.velocity = new Vector2(0, 0);
    }

    public void resetmovementafterswordup()
    {
        movement.yeet.velocity = new Vector2(0, 1);
        isupattack = false;
        reducedamagebyhalf = false;
    }

    public void reduceswordattackrange()
    {
        swordAttackRange = swordAttackRange - 0.2f;
    }
    public void reducehammerattackrange()
    {
        swordAttackRange = swordAttackRange - 0.7f;
        reducedamagebyhalf = false;
    }

    public void resetDaggerTrigger()
    {
        animator.ResetTrigger("daggerattack");
        hasNOknockback = false;
        trippledamage = false;
        animator.ResetTrigger("daggerdown");
        isONLYupattack = false;
        animator.ResetTrigger("daggerup");
        movement.attackrestriction = false;
    }

    public void daggernoknockback()
    {
        hasNOknockback = true;
    }

    public void dealtrippledamage()
    {
        trippledamage = true;
    }

    public void isupslash()
    {
        isONLYupattack = true;
    }

    public void onlymoverestriction()
    {
        movement.attackrestriction = true;
        movement.yeet.velocity = new Vector2(0, movement.yeet.velocity.y);
    }


    #endregion



    #region Shockwaves and other instantiated things

    public void instantiateshockwaveonground()
    {

        if(memory.swordgroundshockwave == true )
        {

        
        if(movement.transform.localScale.x < 1f)
        {
            var Shockwaves = Instantiate(shockWaveOnGround, new Vector3(movement.transform.localPosition.x, movement.transform.localPosition.y, 0), Quaternion.identity);
            Shockwaves.transform.localScale = new Vector2(-3, 3);
        }
        else { var Shockwave = Instantiate(shockWaveOnGround, new Vector3(movement.transform.localPosition.x, movement.transform.localPosition.y, 0), Quaternion.identity);  }
        }

    }

    public void instantiateLightningsword()
    {

        if (memory.lightningstrike == true)
        {


            if (movement.transform.localScale.x < 1f)
            {
                var Lightnings = Instantiate(Lightningstrike, new Vector3(movement.transform.localPosition.x -1.6f, movement.transform.localPosition.y, 0), Quaternion.identity);
               
            }
            else { var Lightningst = Instantiate(Lightningstrike, new Vector3(movement.transform.localPosition.x+1.6f, movement.transform.localPosition.y, 0), Quaternion.identity); }
        }

    }

   
    #endregion


    #region Damageenemies

    public void Damageenemies()
    {

        if (boosteddown == true)
        {
            movement.yeet.velocity = new Vector2(0, -17 - (downdamagecounter / 2)); downdamagecounter++;

            if (downdamagecounter >= 7) reducedamagebyhalf = false;
        }
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swordHitbox.position, swordAttackRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)


            {
                if (reducedamagebyhalf == true)
                {
                    enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage / 2);

                }
                else if (trippledamage == true) enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage * 3);
                else enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage);
                if (enemy.GetComponent<Moveenemy>() != null)
                {



                    bool left = false;
                    if (hasNOknockback == false)
                    {
                        if (movement.transform.localScale.x < 1f) left = true;
                        if (isupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 4, left);
                        else if (isdownattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(0.3f, -15, left);
                        else if (isONLYupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(4, 1f, left);
                        else
                            enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 1, left);

                    }




                }
                Debug.Log("hit enemy");
            }
        }
    }


    public void Damageenemieswithdownslash()
    {

        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(downslashhitbox.position, swordAttackRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)


            {
                if (reducedamagebyhalf == true)
                {
                    enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage / 2);

                }
                else if (trippledamage == true) enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage * 3);
                else enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage);
                if (enemy.GetComponent<Moveenemy>() != null)
                {



                    bool left = false;
                    if (hasNOknockback == false)
                    {
                        if (movement.transform.localScale.x < 1f) left = true;
                        if (isupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 4, left);
                        else if (isdownattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(0.3f, -15, left);
                        else
                            enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 1, left);

                    }




                }
                Debug.Log("hit enemy");
            }
        }
    }

      public void Damageenemiesupwards()
    {

        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(upslashhitbox.position, swordAttackRange * 1.3f );
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)


            {
                if (reducedamagebyhalf == true)
                {
                    enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage / 2);

                }
                else if (trippledamage == true) enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage * 3);
                else enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage);
                if (enemy.GetComponent<Moveenemy>() != null)
                {



                    bool left = false;
                    if (hasNOknockback == false)
                    {
                        if (movement.transform.localScale.x < 1f) left = true;
                        if (isupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 4, left);
                        else if   (isONLYupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(0, 5f, left);
                            else if (isdownattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(0.3f, -15, left);
                        else
                            enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 1, left);

                    }




                }
                Debug.Log("hit enemy");
            }
        }
    }


    public void Damageenemiesbackwards()
    {


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(backslashhitbox.position, swordAttackRange );
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)


            {
                if (reducedamagebyhalf == true)
                {
                    enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage / 2);

                }
                else if (trippledamage == true) enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage * 3);
                else enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage);
                if (enemy.GetComponent<Moveenemy>() != null)
                {



                    bool left = false;
                    if (hasNOknockback == false)
                    {
                        if (movement.transform.localScale.x < 1f) left = true;
                        if (isupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 4, left);
                        else if (isONLYupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(-4, 1f, left);
                
                        else
                            enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 1, left);

                    }




                }
                Debug.Log("hit enemy");
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(swordHitbox.position, swordAttackRange);
        Gizmos.DrawWireSphere(backslashhitbox.position, swordAttackRange);
        Gizmos.DrawWireSphere(upslashhitbox.position, swordAttackRange * 1.3f);
        Gizmos.DrawWireSphere(downslashhitbox.position, swordAttackRange);
    }
    #endregion 


}
