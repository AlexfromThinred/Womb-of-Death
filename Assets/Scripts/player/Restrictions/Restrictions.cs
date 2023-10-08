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
    public Transform spearHitBox;
    public Transform spearupHitBox;
    public Transform UpandFront;
    public bool reducedamagebyhalf;
    public bool boosteddown;
    public int downdamagecounter;
    public bool hasNOknockback;
    public bool trippledamage;
    public bool doubledamage;



    public bool Hammerfarfalling;
    public bool Hammerjumpdown;

    public GameObject shockWaveOnGround;
    public GameObject Lightningstrike;
    public GameObject Earthstab;
    public GameObject tidalWavethrow;
    public GameObject Fireslash;
    public GameObject airDrill;

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

    public void Spearstart()
    {
        if (movement.transform.localScale.x < 1f)
            movement.yeet.velocity = new Vector2(-1, 0);
        else movement.yeet.velocity = new Vector2(1, 0);
        attack.inComboAttack = true;
      
      

        movement.attackrestriction = true;
    }


    public void Spearsecond()
    {
        if (attack.attackQueuedUp == false)
        {
            animator.SetTrigger("stopattack");
            attack.inComboAttack = false;
            movement.attackrestriction = false;
        
       
        } else
        if (movement.transform.localScale.x < 1f)
            movement.yeet.velocity = new Vector2(-3, 0);
        else movement.yeet.velocity = new Vector2(3, 0);
        attack.attackQueuedUp = false;
    }

    public void Spearend()
    {
        attack.inComboAttack = false;

        attack.attackQueuedUp = false;
        doubledamage = false;
        movement.attackrestriction = false;
        animator.SetTrigger("stopattack");
    }

    public void Spearupstart()
    {

      
        movement.yeet.velocity = new Vector2(0, 0);
        swordAttackRange = swordAttackRange + 0.6f;

        movement.attackrestriction = true;
    }
    public void Spearupsecond()
    {
        isONLYupattack = true;
    }

    public void Spearupend()
    {

        isONLYupattack = false;

        swordAttackRange = swordAttackRange - 0.6f;

        movement.attackrestriction = false;
    }





    public void Hammerupstart()
    {
        reducedamagebyhalf = true;
        movement.yeet.velocity = new Vector2(0, 0);
      
        movement.attackrestriction = true;
    }

    public void Hammerstart()
    {
     
        attack.inComboAttack = true;
        movement.yeet.velocity = new Vector2(0, 0);
        swordAttackRange = swordAttackRange + 0.6f;

        movement.attackrestriction = true;
    }

    public void dealdoubledamage()
    {

        doubledamage = true;
    }

    public void Hammerend()
    {

        doubledamage = false;
        attack.inComboAttack = false;
        movement.attackrestriction = false;
        swordAttackRange = swordAttackRange - 0.6f;
        animator.SetTrigger("stopattack");
        isONLYupattack = false;
        attack.attackQueuedUp = false;
    }

    public void Secondhammerstrike()
    {
        if (attack.attackQueuedUp == false)
        {
            animator.SetTrigger("stopattack");
            attack.inComboAttack = false;
            movement.attackrestriction = false;
            isONLYupattack = false;
            swordAttackRange = swordAttackRange - 0.6f;


        } else
        {
            doubledamage = true;
            attack.attackQueuedUp = false;
            isONLYupattack = true;
        }


    }

    public void Hammerupjump()
    {
       downdamagecounter = 1;
        reducedamagebyhalf = true;
        isONLYupattack = true;
        if (movement.transform.localScale.x < 1f)
            movement.yeet.velocity = new Vector2(-8f, 7f);
        else movement.yeet.velocity = new Vector2(8f, 7f);
        Hammerfarfalling = true;
      
    }

    public void Hammerupdown()
    {
        swordAttackRange = swordAttackRange + 1f;
        movement.yeet.velocity = new Vector2(0, -14);
        isdownslashingendless = true;
        boosteddown = true;
       

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
        isONLYupattack = false;
        Hammerfarfalling = false;
        doubledamage = false;
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

        if (movement.transform.localScale.x < 1f)
            movement.yeet.velocity = new Vector2(-1, 2);
        else movement.yeet.velocity = new Vector2(1, 2);

        movement.attackrestriction = true;

    }

    public void sworddownfall()
    {
        if (movement.yeet.velocity.y == 0) Debug.Log("sdfasfafawfawf");
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

        movement.yeet.gravityScale = 0.65f;


    }

    public void swordslashthree()
    {
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

            isdownattack = true;
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

        movement.yeet.gravityScale = 0.65f;
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
        swordAttackRange = swordAttackRange - 1f;
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
    public void onlymoverestrictionInAllAchses()
    {
        movement.attackrestriction = true;
        movement.yeet.velocity = new Vector2(0, 0);
    }

    public void Hammerdown()
    {
        isONLYupattack = true;
        movement.yeet.velocity = new Vector2(0, -9);
    }
    #endregion
    public void Hammerdownend()
    {
        isONLYupattack = false;
        movement.attackrestriction = false;
    }


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

    public void instantiateEarthstabhammer()
    {
        
        if (memory.earthstabhammer == true)
        {


            if (movement.transform.localScale.x < 1f)
            {
                var Earthstableft = Instantiate(Earthstab, new Vector3(movement.transform.localPosition.x - 4.6f, movement.transform.localPosition.y -0.1f, 0), Quaternion.identity);

            }
            else { var Earthstabright = Instantiate(Earthstab, new Vector3(movement.transform.localPosition.x + 4.6f, movement.transform.localPosition.y - 0.1f, 0), Quaternion.identity); }

            if (movement.transform.localScale.x < 1f)
            {
                var Earthstableft = Instantiate(Earthstab, new Vector3(movement.transform.localPosition.x - 2.6f, movement.transform.localPosition.y - 0.1f, 0), Quaternion.identity);

            }
            else { var Earthstabright = Instantiate(Earthstab, new Vector3(movement.transform.localPosition.x + 2.6f, movement.transform.localPosition.y - 0.1f, 0), Quaternion.identity); }

            if (movement.transform.localScale.x < 1f)
            {
                var Earthstableft = Instantiate(Earthstab, new Vector3(movement.transform.localPosition.x - 3.6f, movement.transform.localPosition.y - 0.1f, 0), Quaternion.identity);

            }
            else { var Earthstabright = Instantiate(Earthstab, new Vector3(movement.transform.localPosition.x + 3.6f, movement.transform.localPosition.y - 0.1f, 0), Quaternion.identity); }
        }

    }

    public void instantiateLightningHammerdown()
    {
        if (memory.lightningstrikeHammer == true)
        {        
          var Lightnings = Instantiate(Lightningstrike, new Vector3(movement.transform.localPosition.x - 1.6f, movement.transform.localPosition.y, 0), Quaternion.identity);
          var Lightningst = Instantiate(Lightningstrike, new Vector3(movement.transform.localPosition.x + 1.6f, movement.transform.localPosition.y, 0), Quaternion.identity); 
        }
    }

    public void instantiateSecondLightningHammerdown()
    {
        if (memory.lightningstrikeHammer == true)
        {
            var Lightnings = Instantiate(Lightningstrike, new Vector3(movement.transform.localPosition.x - 2.6f, movement.transform.localPosition.y, 0), Quaternion.identity);
            var Lightningst = Instantiate(Lightningstrike, new Vector3(movement.transform.localPosition.x + 2.6f, movement.transform.localPosition.y, 0), Quaternion.identity);
        }
    }

    public void instantiateTidalWaveSpear()
    {
        if (memory.tidalWave == true)
        {
            if (movement.transform.localScale.x < 1f)
            {
                var Tidalwaveleft = Instantiate(tidalWavethrow, new Vector3(movement.transform.localPosition.x - 1.6f, movement.transform.localPosition.y - 0.4f, 0), Quaternion.identity);
                Tidalwaveleft.GetComponent<Tidalwave>().left = true;
            }
            else { var Tidalwavere = Instantiate(tidalWavethrow, new Vector3(movement.transform.localPosition.x + 1.6f, movement.transform.localPosition.y - 0.4f, 0), Quaternion.identity);  }
           
        }
    }

    public void instantiateTidalWaveDaggerUP()
    {
        if (memory.tidalWave == true)
        {
           
                var Tidalwaveleft = Instantiate(tidalWavethrow, new Vector3(movement.transform.localPosition.x - 1.6f, movement.transform.localPosition.y - 0.4f, 0), Quaternion.identity);
                Tidalwaveleft.GetComponent<Tidalwave>().left = true;
            
                var Tidalwavere = Instantiate(tidalWavethrow, new Vector3(movement.transform.localPosition.x + 1.6f, movement.transform.localPosition.y - 0.4f, 0), Quaternion.identity); 

        }
    }

    public void instantiateFireslash()
    {
        if (memory.fireslash == true)
        {

            if (movement.transform.localScale.x < 1f)
            {
                var Fireleft = Instantiate(Fireslash, new Vector3(movement.transform.localPosition.x - 1.6f, movement.transform.localPosition.y - 0.22f, 0), Quaternion.identity);
                Fireleft.GetComponent<Tidalwave>().left = true;
            }
            else { var Firere = Instantiate(Fireslash, new Vector3(movement.transform.localPosition.x + 1.6f, movement.transform.localPosition.y - 0.22f, 0), Quaternion.identity); }

        }
    }

    public void instantiateAirdrill()
    {
        if (memory.fireslash == true)
        {

            if (movement.transform.localScale.x < 1f)
            {
                var Airdrilllef = Instantiate(airDrill, new Vector3(movement.transform.localPosition.x - 1.5f, movement.transform.localPosition.y -0.17f, 0), Quaternion.identity);
                Airdrilllef.GetComponent<Tidalwave>().left = true;
            }
            else { var Airdrillre = Instantiate(airDrill, new Vector3(movement.transform.localPosition.x + 1.5f, movement.transform.localPosition.y - 0.17f, 0), Quaternion.identity); }

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
            if (Hammerfarfalling == true && downdamagecounter >= 9) doubledamage = true;
        }
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swordHitbox.position, swordAttackRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)


            {
                if (reducedamagebyhalf == true)
                {
                    enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage / 2, false, false);

                }
                else if (trippledamage == true) enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage * 3, false, false);
                else if (doubledamage == true) enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage * 2, false, false);
                else enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage, false, false);
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


    public void DamageenemieswithSpear()
    {

       
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(spearHitBox.position, new Vector2 (2.15f,1.2f),0);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Enemyhealth>() != null) { 


            
               
             
                 if (doubledamage == true) enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage * 2, false, false);
                else enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage, false, false);
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
                    enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage / 2, false, false);

                }
                else if (trippledamage == true) enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage * 3, false, false);
                else enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage, false, false);
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
                    enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage / 2, false, false);

                }
                else if (trippledamage == true) enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage * 3, false, false);
                else enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage, false, false);
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

    public void DamageenemiesUpandFront()
    {


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(upslashhitbox.position, swordAttackRange * 1.3f);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)


            {
                if (reducedamagebyhalf == true)
                {
                    enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage / 2, false, false);

                }
                else if (trippledamage == true) enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage * 3, false, false);
                else enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage, false, false);
                if (enemy.GetComponent<Moveenemy>() != null)
                {



                    bool left = false;
                    if (hasNOknockback == false)
                    {
                        if (movement.transform.localScale.x < 1f) left = true;
                        if (isupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 4, left);
                        else if (isONLYupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(0, 5f, left);
                        else if (isdownattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(0.3f, -15, left);
                        else
                            enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 1, left);

                    }




                }
                Debug.Log("hit enemy");
            }
        }
    }

    public void DamageenemiesupSpear()
    {


        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(spearupHitBox.position, new Vector2(1,2.5f), -30);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)


            {
               
                enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage, false, false);
                if (enemy.GetComponent<Moveenemy>() != null)
                {

                    bool left = false;
                    if (hasNOknockback == false)
                    {
                        if (movement.transform.localScale.x < 1f) left = true;
                       
                         if (isONLYupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(0, 3f, left);
                     
                        else
                            enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 1, left);
                    }
                }
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
                    enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage / 2 , false,false);

                }
                else if (trippledamage == true) enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage * 3, false, false);
                else enemy.GetComponent<Enemyhealth>().dealdamage(attack.currentWeapon.damage, false, false);
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

        Gizmos.matrix = this.transform.localToWorldMatrix;
        Gizmos.DrawWireSphere(swordHitbox.position, swordAttackRange);
        Gizmos.DrawWireSphere(backslashhitbox.position, swordAttackRange);
        Gizmos.DrawWireSphere(upslashhitbox.position, swordAttackRange * 1.3f);
        Gizmos.DrawWireSphere(downslashhitbox.position, swordAttackRange);
        Gizmos.DrawWireCube(spearHitBox.position, new Vector3( 2.15f, 1.2f,0));
      //  Gizmos.DrawWireCube(spearupHitBox.position, new Vector3(1, 2.5f,0), -30);          ------>>>>>> dosent work right now with rotation
    }
    #endregion 


}
