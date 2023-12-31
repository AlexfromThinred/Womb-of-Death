using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restrictions : MonoBehaviour
{
    public Audiomanager audioManager;
    public Attack attack;
    public Movement movement;
    public Animator animator;
    public Memory memory;
    public float currentAttackRange;
    

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
    public Transform Downspear;
    public bool reducedamagebyhalf;
    public bool boosteddown;
    public int downdamagecounter;
    public bool hasNOknockback;
    public bool trippledamage;
    public bool doubledamage;
    public bool bigknockback;
    public bool isnormalHammerattack;
    public bool isfirstSpearattack;
    public bool isreallyupattack;


    public bool Hammerfarfalling;
    public bool Hammerjumpdown;

    public GameObject shockWaveOnGround;
    public GameObject Lightningstrike;
    public GameObject Earthstab;
    public GameObject tidalWavethrow;
    public GameObject Fireslash;
    public GameObject airDrill;
    public GameObject MosterSlice;
    public GameObject Earthwall;

    public void Start()
    {
       
        audioManager = FindFirstObjectByType<Audiomanager>();
        movement = GetComponentInParent<Movement>();
        attack = GetComponentInParent<Attack>();
        animator = GetComponent<Animator>();
        memory = GetComponentInParent<Memory>();
        isupattack = false;
        isdownattack = false;
        isdownslashingendless = false;
        trippledamage = false;
    }

   public void ResettheStop()
    {
        animator.ResetTrigger("stopattack");
        movement.attackrestriction = false;
        movement.attackrestrictionwithgravity = false;
        currentAttackRange = 0.5f;
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

    #region Spell and Step Audio

    public void FireballFocus()
    {
        audioManager.Play("Fireballfocus");
    }

    public void StepleftAudio()
    {
        audioManager.Play("Stepgrasleft");
    }

    public void SteprightAudio()
    {
        audioManager.Play("Stepgtasright");
    }
   
       
    
    #endregion



    #region singleattacks

    public void Spearstart()
    {
        isfirstSpearattack = true;
        if (movement.transform.localScale.x < 1f)
            movement.yeet.velocity = new Vector2(-1, 0);
        else movement.yeet.velocity = new Vector2(1, 0);
        attack.inComboAttack = true;
      
      

        movement.attackrestriction = true;
    }

    public void Speardownaccele()
    {
        movement.isjumping = true;
        movement.yeet.velocity = new Vector2(movement.yeet.velocity.x, 7.5f);
        
    }

    public void Speardowndashattack()
    {
        
        bigknockback = true;
        if (movement.boosted == false)
        {
            movement.isjumping = false;
            animator.SetTrigger("stopattack");

           
            bigknockback = false;

        } 

    }

    public void Speardowndashattackending()
    {
        animator.SetTrigger("stopattack");

        movement.isjumping = false;


    }

    public void Spearsecond()
    {
        isfirstSpearattack = false;
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

    public void Spearthird()
    {
        bigknockback = true;
        if (attack.attackQueuedUp == false)
        {
            animator.SetTrigger("stopattack");
            attack.inComboAttack = false;
            movement.attackrestriction = false;
            bigknockback = false;

        }
        else
        if (movement.transform.localScale.x < 1f)
            movement.yeet.velocity = new Vector2(-3, 0);
        else movement.yeet.velocity = new Vector2(3, 0);
        attack.attackQueuedUp = false;
      

    }

    public void Spearend()
    {
        attack.inComboAttack = false;
        bigknockback = false;
        attack.attackQueuedUp = false;
        doubledamage = false;
        movement.attackrestriction = false;
        animator.SetTrigger("stopattack");
        isfirstSpearattack = false;
    }

    public void Spearupstart()
    {

        isONLYupattack = true;
     //   movement.attackrestriction = true;
        

     
    }
    public void Spearupsecond()
    {
        isONLYupattack = true;
    }

    public void Spearupend()
    {

        isONLYupattack = false;

        

      //  movement.attackrestriction = false;
    }


    public void Hammerupstart()
    {
        reducedamagebyhalf = true;
        movement.yeet.velocity = new Vector2(0, 0);
        audioManager.Play("Hammeup");
        movement.attackrestriction = true;
    }

    public void Hammerstart()
    {
     
        attack.inComboAttack = true;
        movement.yeet.velocity = new Vector2(0, 0);
       
        isnormalHammerattack = true;
        movement.attackrestriction = true;
        audioManager.Play("Hammerswing");
    }

    public void dealdoubledamage()
    {

        doubledamage = true;
    }

    public void Hammerend()
    {
        isnormalHammerattack = false;
        doubledamage = false;
        attack.inComboAttack = false;
        movement.attackrestriction = false;
       
        animator.SetTrigger("stopattack");
        isONLYupattack = false;
        attack.attackQueuedUp = false;
    }

    public void HammerUpStrikeAudio()
    {
        audioManager.Play("Hammersecondswing");
    }

    public void HammerSecondStrikeaudio()
    {
        audioManager.Play("Hammersecondswing");
    }
    public void HammerSwingAudio()
    {
        audioManager.Play("Hammerswing");
    }
   
    public void Secondhammerstrike()
    {
        isnormalHammerattack = false;
        if (attack.attackQueuedUp == false)
        {
            animator.SetTrigger("stopattack");
            attack.inComboAttack = false;
            movement.attackrestriction = false;
            isONLYupattack = false;
           


        } else
        {
            doubledamage = true;
            attack.attackQueuedUp = false;
            isONLYupattack = true;
            audioManager.Play("Hammerswing");
            
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
       
        movement.yeet.velocity = new Vector2(0, -14);
        isdownslashingendless = true;
        boosteddown = true;
       

    }
    public void Hammerfalling()
    {
        animator.ResetTrigger("nexthammerup");
        downdamagecounter ++;
        if (downdamagecounter >= 6 && downdamagecounter <= 11) animator.SetTrigger("nexthammerup");
        movement.yeet.velocity = new Vector2(0, -14);
    }
    public void Hammerfallingsecond()
    {
        animator.ResetTrigger("nexthammerup");
        downdamagecounter++;
        if (downdamagecounter >=11) animator.SetTrigger("thirdhammerip");
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

    public void SwordspecialGarenE()
    {
        movement.attackrestriction = true;
        movement.yeet.gravityScale = 0;
        movement.yeet.velocity = new Vector2(0, 0);
      
        audioManager.Play("SwordSwing");
        audioManager.Play("Swordunsheath");
        movement.attackrestriction = true;
    }

    public void sworduupslash()
    {
       
        isupattack = true;
        movement.yeet.velocity = new Vector2(0, 0);
        movement.attackrestriction = true;
        reducedamagebyhalf = true;
        audioManager.Play("SwordSwing");
        audioManager.Play("Swordunsheath");
    }

    public void Stopattack()
    {
        animator.SetTrigger("stopattack");
        movement.attackrestriction = false;
        movement.attackrestrictionwithgravity = false;
        isupattack = false;
        reducedamagebyhalf = false;
        doubledamage = false;
        attack.inComboAttack = false;
        attack.attackQueuedUp = false;
        movement.yeet.velocity = new Vector2(0, 0);
        isreallyupattack = false;
    }

    public void SwordUpDebugger()
    {
        movement.yeet.velocity = new Vector2(0, 0);
      
        movement.yeet.gravityScale = 0.65f;
    }

    public void SwordUpslashDashAttack()
    {
      
        reducedamagebyhalf = false;
        isupattack = false;
        if (movement.boosted == false)
        {
            animator.SetTrigger("stopattack");
            movement.yeet.gravityScale = 0.65f;
            movement.attackrestriction = false;
            movement.attackrestrictionwithgravity = false;
            movement.yeet.velocity = new Vector2(0, 0);




        }
        else isreallyupattack = true;
     



    }

    public void sworduupslashmovement()
    {
        movement.yeet.gravityScale = 0;
        movement.yeet.velocity = new Vector2(0, 8f);
        animator.ResetTrigger("swordattackup");

    }

    public void sworddownstart()
    {
        audioManager.Play("SwordSwing");
        audioManager.Play("Swordunsheath");
        isdownattack = true;
        reducedamagebyhalf = true;

        if (movement.transform.localScale.x < 1f)
            movement.yeet.velocity = new Vector2(-1, 2);
        else movement.yeet.velocity = new Vector2(1, 2);

        movement.attackrestriction = true;

    }

    public void sworddownfall()
    {
      
        movement.yeet.velocity = new Vector2(0, -15);
        isdownslashingendless = true;
        boosteddown = true;
      

    }

    public void swordFalling()
    {
        movement.yeet.velocity = new Vector2(0, -15);

    }

    public void swordslashone()
    {
       
        reducedamagebyhalf = true;
        movement.attackrestriction = true;
        if (movement.transform.localScale.x < 1f)
            movement.yeet.velocity = new Vector2(-4f, -0.5f);
        else movement.yeet.velocity = new Vector2(4f, -0.5f);
        movement.yeet.gravityScale = 0;
        audioManager.Play("SwordSwing");
        audioManager.Play("Swordunsheath");
    }
    public void swordstillslash()
    {
     
        reducedamagebyhalf = true;
        movement.attackrestriction = true;
       
            movement.yeet.velocity = new Vector2(0, 1f);
     
        movement.yeet.gravityScale = 0;
        audioManager.Play("SwordSwing");
        audioManager.Play("Swordunsheath");
    }

    public void swordstillback()
    {
        
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            movement.yeet.velocity = new Vector2(0, -0.5f);
            movement.playermovementspeed = 0;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movement.yeet.velocity = new Vector2(-8f, 2f);
            movement.playermovementspeed = -4;
        }
       else if (Input.GetKey(KeyCode.D)) { movement.yeet.velocity = new Vector2(8f, 2); movement.playermovementspeed = 4; }
            
        else movement.yeet.velocity = new Vector2(0, -0.5f);

      


    }

    public void swordstillend()
    {
        reducedamagebyhalf = false;
        if (attack.attackQueuedUp == false)
        {
            animator.SetTrigger("stopattack");
            attack.inComboAttack = false;
            resetweaponrestriction();

        


        }
        else
        {
           
            audioManager.Play("SwordSwing");
           

            attack.attackQueuedUp = false;
        }

        movement.yeet.gravityScale = 0.65f;


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
          
            attack.inComboAttack = false;
            resetweaponrestriction();
            animator.SetTrigger("stopattack");

        }
        else
        {
            if (movement.transform.localScale.x < 1f)
                movement.yeet.velocity = new Vector2(-2f, 2);
            else movement.yeet.velocity = new Vector2(2f, 2);
            audioManager.Play("SwordSwing");

            attack.attackQueuedUp = false;
        }

        movement.yeet.gravityScale = 0.65f;


    }

    public void swordslashthree()
    {
        animator.ResetTrigger("stopattack");
        if (attack.attackQueuedUp == false)
        {
          
            attack.inComboAttack = false;
            resetweaponrestriction();
            animator.SetTrigger("stopattack");
           
         
           


        }
        else
        {
            audioManager.Play("SwordSwing");
            isdownattack = true;
            movement.attackrestrictionwithgravity = true;
            movement.yeet.velocity = new Vector2(0f, -2f);
            attack.attackQueuedUp = false;
           // attack.currentMeeleCooldown = attack.currentWeapon.cooldown;
        }




    }

    public void swordstilldown()
    {
        movement.yeet.velocity = new Vector2(0, -1);
    }


    public void changetonormal()
    {

       
        isdownattack = false;
        reducedamagebyhalf = false;
        
       
        movement.attackrestriction = false;
        animator.SetTrigger("stopattack");
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
        isONLYupattack = false;
        isreallyupattack = false;
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

 
    public void reducehammerattackrange()
    {
       
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

    public void isUpslash()
    {
        isONLYupattack = true;
    }

    public void isFrontUpslash()
    {
        isreallyupattack = true;
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

    public void ResettriggersHammer()
    {
        animator.ResetTrigger("earthwallhammer");
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


    public void instantiateEarthwall()
    {

        if (memory.earthstabhammer == true)
        {


           

            if (movement.transform.localScale.x < 1f)
            {
                var Earthstableft = Instantiate(Earthwall, new Vector3(movement.transform.localPosition.x - 2.6f, movement.transform.localPosition.y - 0.1f, 0), Quaternion.identity);

            }
            else { var Earthstabright = Instantiate(Earthwall, new Vector3(movement.transform.localPosition.x + 2.6f, movement.transform.localPosition.y - 0.1f, 0), Quaternion.identity); }

            
        }

    }

    public void instantiateLightningHammerdown()
    {
        if (memory.lightningstrikeHammer == true)
        {        
          var Lightnings = Instantiate(Lightningstrike, new Vector3(movement.transform.localPosition.x - 1.6f, movement.transform.localPosition.y + 0.8f, 0), Quaternion.identity);
          var Lightningst = Instantiate(Lightningstrike, new Vector3(movement.transform.localPosition.x + 1.6f, movement.transform.localPosition.y + 0.8f, 0), Quaternion.identity); 
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

    public void instantiateGarenE()
    {
        
            if (movement.transform.localScale.x < 0)
            {
                var MosterSliceobj = Instantiate(MosterSlice, new Vector3(movement.transform.localPosition.x , movement.transform.localPosition.y , 0), Quaternion.identity);
                MosterSliceobj.GetComponent<Groundshockwave>().leftdraw = true;
            }
            else { var MosterSliceobj = Instantiate(MosterSlice, new Vector3(movement.transform.localPosition.x, movement.transform.localPosition.y, 0), Quaternion.identity); }

        
    }


    #endregion


    #region Damageenemies

    public void Damageenemies()
    {

        if (boosteddown == true)
        {
           // movement.yeet.velocity = new Vector2(0, -17 - (downdamagecounter / 2)); downdamagecounter++;

            if (downdamagecounter >= 6) reducedamagebyhalf = false;
            if (Hammerfarfalling == true && downdamagecounter >= 11) doubledamage = true;
        }
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swordHitbox.position, currentAttackRange);
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
                        if (isupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(2f, 3.8f, left);
                        else if (isreallyupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 5.2f, left);
                        else if (isdownattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, -9, left);
                        else if (isONLYupattack == true && GetComponentInParent<Movement>().boosted == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(10, 0f, left);
                        else if (isnormalHammerattack == true && GetComponentInParent<Movement>().boosted == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(3, 3f, left);
                        else if (isONLYupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(4, 1f, left);
                        else if (GetComponentInParent<Movement>().boosted == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(11, 1f, left);
                        else
                            enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 1, left);

                    }




                }
                
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
                        else if (bigknockback == false && isfirstSpearattack == false && GetComponentInParent<Movement>().boosted == true)
                        {
                            enemy.GetComponent<Moveenemy>().Knockbackafterattack(5, 5f, left);
                           // attack.currentMeeleCooldown = 0.3f;
                        }
                        else if (bigknockback == true && GetComponentInParent<Movement>().boosted == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(8, 1f, left);
                        else if (bigknockback == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(3, 1f, left);
                        else
                            enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 1, left);

                    }




                }
                
            }
        }
    }


    public void Damageenemieswithdownslash()
    {

        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(downslashhitbox.position, currentAttackRange);
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
             
            }
        }
    }

    public void DamageenemieswithDownSpear()
    {
        //Collider2D[] enemyandotherstuff = Physics2D.OverlapBoxAll(Downspear.position, new Vector2(1.1f, 2f), 0);

        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(Downspear.position, new Vector2(1.1f, 2f), 0);
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
                        if (isupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(0f, -3, left);
                        else if (isdownattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(0f, -3, left);
                        else
                            enemy.GetComponent<Moveenemy>().Knockbackafterattack(0f, -3, left);

                    }




                }
              
            }
        }
    }


    public void Damageenemiesupwards()
    {

        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(upslashhitbox.position, currentAttackRange * 1.3f );
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
                        else if   (isONLYupattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(0, 3.3f, left);
                            else if (isdownattack == true) enemy.GetComponent<Moveenemy>().Knockbackafterattack(0.3f, -15, left);
                        else
                            enemy.GetComponent<Moveenemy>().Knockbackafterattack(1.5f, 1, left);

                    }




                }
                
            }
        }
    }

    public void DamageenemiesUpandFront()
    {


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(upslashhitbox.position, currentAttackRange * 1.3f);
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


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(backslashhitbox.position, currentAttackRange);
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
                            enemy.GetComponent<Moveenemy>().Knockbackafterattack(-1.5f, 1, left);

                    }




                }
              
            }
        }
    }


    private void OnDrawGizmosSelected()
    {

        Gizmos.matrix = this.transform.localToWorldMatrix;
        Gizmos.DrawWireSphere(swordHitbox.position, currentAttackRange);
        Gizmos.DrawWireSphere(backslashhitbox.position, currentAttackRange);
        Gizmos.DrawWireSphere(upslashhitbox.position, currentAttackRange * 1.3f);
        Gizmos.DrawWireSphere(downslashhitbox.position, currentAttackRange);
        Gizmos.DrawWireCube(spearHitBox.position, new Vector3( 2.15f, 1.2f,0));
        Gizmos.DrawWireCube(Downspear.position, new Vector3(1.1f, 2f, 0));
        //  Gizmos.DrawWireCube(spearupHitBox.position, new Vector3(1, 2.5f,0), -30);          ------>>>>>> dosent work right now with rotation
    }
    #endregion 


}
