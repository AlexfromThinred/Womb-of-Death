using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public WeaponData currentWeapon;
    public bool firstAttackReady;
    public bool secondAttackReady;
    public bool comboAttacks;
    public bool attackQueuedUp;
    public bool inComboAttack;
    public bool specialReady;
    public float currentsecondCooldown;
    public float currentfirstCooldown;
    public float specialWeaponCooldown;

    public GameObject arrow;
    public GameObject swing;
    public Animator animator;
    public Movement movement;
    public Memory memory;
    public Restrictions restrictions;
    public Showcooldown cooldown;


    public float swordAttackRange;
    public float hammerAttackRange;
    public float daggerAttackRange;
    public float spearAttackRange;

    void Start()
    {
        restrictions = GetComponentInChildren<Restrictions>();
        animator = GetComponentInChildren<Animator>();
        movement = GetComponent<Movement>();
        memory = GetComponent<Memory>();
        cooldown = FindAnyObjectByType<Showcooldown>();

        swordAttackRange = 0.5f;
        restrictions.currentAttackRange = 0.5f;
        hammerAttackRange = 1.3f;
        daggerAttackRange = 0.5f;
        spearAttackRange = 1.1f;
    }

    /*
     * 
     * 
     * 
     * 
     * 
     *                                          ÜBERALL COOLDOWNS ADDEN cooldown.maxweaponcooldown für Showcooldown 




                                                ZUSÄTZLICH RANGEDCOOLDOWN AUF SECONDWEAPONCOOLDOWN ÄNDERN
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * */


    // Update is called once per frame
    void Update()
    {
        // Cooldown Management
        firstAttackReady = (currentfirstCooldown <= 0);
        secondAttackReady = (currentsecondCooldown <= 0);
        specialReady = (specialWeaponCooldown <= 0);
        currentWeapon = memory.currentWeaponData;

        if (currentsecondCooldown > 0 && memory.activeWeapons[1])
        {
            currentsecondCooldown -= Time.deltaTime;
            if (currentWeapon.type == WeaponData.Type.Sword && movement.grounded && currentsecondCooldown > currentWeapon.cooldown / 25)
            {
                currentsecondCooldown = currentWeapon.cooldown / 25;
            }
        }
        if (currentfirstCooldown > 0 && memory.activeWeapons[0])
        {
            currentfirstCooldown -= Time.deltaTime;
            if (currentWeapon.type == WeaponData.Type.Sword && movement.grounded && currentfirstCooldown > currentWeapon.cooldown / 25)
            {
                currentfirstCooldown = currentWeapon.cooldown / 25;
            }
        }
        if (specialWeaponCooldown > 0) specialWeaponCooldown -= Time.deltaTime;

        // Main LMB Input
        if (Input.GetKeyDown(KeyCode.Mouse0) && movement.movementrestriction == false && movement.boosted == false && movement.attackrestriction == false)
        {




            switch (memory.activeWeapons[memory.activeWeapon].type)
            {
                case WeaponData.Type.Bow:
                    // Bow Default Attack
                    if (memory.activeWeapon == 0 && !firstAttackReady)
                    {
                        break;
                    }
                    else if (memory.activeWeapon == 1 && !secondAttackReady)
                    {
                        break;
                    }
                    var projectile = Instantiate(arrow, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0),
                    Quaternion.Euler(0f, 0f, (Mathf.Atan2(Input.mousePosition.y - Camera.main.WorldToScreenPoint(gameObject.transform.localPosition).y, Input.mousePosition.x - Camera.main.WorldToScreenPoint(gameObject.transform.localPosition).x) * Mathf.Rad2Deg)));

                    if (memory.activeWeapon == 0) { currentfirstCooldown = currentWeapon.cooldown; cooldown.maxCooldownFirstWeapon = currentWeapon.cooldown; }



                    else { currentsecondCooldown = currentWeapon.cooldown; cooldown.maxCooldownSecondWeapon = currentWeapon.cooldown; }




                    break;


                case WeaponData.Type.Crossbow:
                    // Crossbow Attack Code


                    break;


                case WeaponData.Type.Sword:
                    if (memory.activeWeapon == 0 && !firstAttackReady)
                    {
                        break;
                    }
                    else if (memory.activeWeapon == 1 && !secondAttackReady)
                    {
                        break;
                    }
                    restrictions.currentAttackRange = 0.8f;
                    inComboAttack = true;
                    if (Input.GetKey(KeyCode.W) && movement.grounded == true)
                    {
                        animator.SetTrigger("swordattackup");
                        if (memory.activeWeapon == 0) { currentfirstCooldown = currentWeapon.cooldown; cooldown.maxCooldownFirstWeapon = currentWeapon.cooldown / 25; }
                        else { currentsecondCooldown = currentWeapon.cooldown; cooldown.maxCooldownSecondWeapon = currentWeapon.cooldown / 25; }
                    }
                    // else if (Input.GetKey(KeyCode.W) && movement.grounded == false) {  }
                    else if (Input.GetKey(KeyCode.S) && movement.grounded == false)
                    {
                        animator.SetTrigger("swordattackdown");
                        if (memory.activeWeapon == 0) { currentfirstCooldown = currentWeapon.cooldown; cooldown.maxCooldownFirstWeapon = currentWeapon.cooldown / 25; }
                        else { currentsecondCooldown = currentWeapon.cooldown; cooldown.maxCooldownSecondWeapon = currentWeapon.cooldown / 25; }
                    }
                    else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                    {

                        inComboAttack = true;
                        animator.SetTrigger("swordattack");
                        if (memory.activeWeapon == 0) { currentfirstCooldown = currentWeapon.cooldown; cooldown.maxCooldownFirstWeapon = currentWeapon.cooldown / 25; }
                        else { currentsecondCooldown = currentWeapon.cooldown; cooldown.maxCooldownSecondWeapon = currentWeapon.cooldown / 25; }
                    }
                    else
                    {

                        inComboAttack = true;
                        animator.SetTrigger("swordstill");
                        if (memory.activeWeapon == 0) { currentfirstCooldown = currentWeapon.cooldown; cooldown.maxCooldownFirstWeapon = currentWeapon.cooldown / 25; }
                        else { currentsecondCooldown = currentWeapon.cooldown; cooldown.maxCooldownSecondWeapon = currentWeapon.cooldown / 25; }
                    }
                    break;



                case WeaponData.Type.Daggers:
                    // Dagger Attack Code

                    if (memory.activeWeapon == 0 && !firstAttackReady)
                    {
                        break;
                    }
                    else if (memory.activeWeapon == 1 && !secondAttackReady)
                    {
                        break;
                    }
                    restrictions.currentAttackRange = 0.5f;
                    if (Input.GetKey(KeyCode.S) && movement.grounded == false)
                    {
                        animator.SetTrigger("daggerdown");
                        if (memory.activeWeapon == 0) { currentfirstCooldown = currentWeapon.cooldown; cooldown.maxCooldownFirstWeapon = currentWeapon.cooldown * 1.4f; }
                        else { currentsecondCooldown = currentWeapon.cooldown; cooldown.maxCooldownSecondWeapon = currentWeapon.cooldown * 1.4f; }
                    }
                    else if (Input.GetKey(KeyCode.W))
                    {
                        animator.SetTrigger("daggerup");
                        if (memory.activeWeapon == 0) { currentfirstCooldown = currentWeapon.cooldown; cooldown.maxCooldownFirstWeapon = currentWeapon.cooldown * 1.4f; }
                        else { currentsecondCooldown = currentWeapon.cooldown; cooldown.maxCooldownSecondWeapon = currentWeapon.cooldown * 1.4f; }
                    }
                    else
                    {
                        animator.SetTrigger("daggerattack");
                        if (memory.activeWeapon == 0) { currentfirstCooldown = currentWeapon.cooldown; cooldown.maxCooldownFirstWeapon = currentWeapon.cooldown; }
                        else { currentsecondCooldown = currentWeapon.cooldown; cooldown.maxCooldownSecondWeapon = currentWeapon.cooldown; }
                    }
                    break;


                case WeaponData.Type.Spear:
                    // Spear Attack Code
                    Debug.Log("Spear");
                    if (memory.activeWeapon == 0 && !firstAttackReady)
                    {
                        break;
                    }
                    else if (memory.activeWeapon == 1 && !secondAttackReady)
                    {
                        break;
                    }
                    restrictions.currentAttackRange = 0.8f;
                    if (Input.GetKey(KeyCode.W))
                    {
                        animator.SetTrigger("Spearup");
                        if (memory.activeWeapon == 0) { currentfirstCooldown = currentWeapon.cooldown; cooldown.maxCooldownFirstWeapon = currentWeapon.cooldown * 1.4f; }
                        else { currentsecondCooldown = currentWeapon.cooldown; cooldown.maxCooldownSecondWeapon = currentWeapon.cooldown * 1.4f; }
                    }
                    else if (Input.GetKey(KeyCode.S) && movement.grounded == false)
                    {
                        animator.SetTrigger("Speardown");
                        if (memory.activeWeapon == 0) { currentfirstCooldown = currentWeapon.cooldown; cooldown.maxCooldownFirstWeapon = currentWeapon.cooldown * 1.4f; }
                        else { currentsecondCooldown = currentWeapon.cooldown; cooldown.maxCooldownSecondWeapon = currentWeapon.cooldown * 1.4f; }
                    }
                    else
                    {
                        animator.SetTrigger("Spear");
                        if (memory.activeWeapon == 0) { currentfirstCooldown = currentWeapon.cooldown; cooldown.maxCooldownFirstWeapon = currentWeapon.cooldown * 1.4f; }
                        else { currentsecondCooldown = currentWeapon.cooldown; cooldown.maxCooldownSecondWeapon = currentWeapon.cooldown * 1.4f; }
                    }
                    break;


                case WeaponData.Type.Hammer:
                    // Hammer Attack Code
                    Debug.Log("Hammer");
                    if (memory.activeWeapon == 0 && !firstAttackReady)
                    {
                        break;
                    }
                    else if (memory.activeWeapon == 1 && !secondAttackReady)
                    {
                        break;
                    }
                    restrictions.currentAttackRange = 1.2f;
                    if (Input.GetKey(KeyCode.W))
                    {
                        animator.SetTrigger("Hammerup");
                        if (memory.activeWeapon == 0) { currentfirstCooldown = currentWeapon.cooldown; cooldown.maxCooldownFirstWeapon = currentWeapon.cooldown - 1; }
                        else { currentsecondCooldown = currentWeapon.cooldown; cooldown.maxCooldownSecondWeapon = currentWeapon.cooldown - 1; }
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        animator.SetTrigger("Hammerdown");
                        if (memory.activeWeapon == 0) { currentfirstCooldown = currentWeapon.cooldown; cooldown.maxCooldownFirstWeapon = currentWeapon.cooldown - 1; }
                        else { currentsecondCooldown = currentWeapon.cooldown; cooldown.maxCooldownSecondWeapon = currentWeapon.cooldown - 1; }
                    }
                    else
                    {
                        animator.SetTrigger("Hammer"); inComboAttack = true;
                        if (memory.activeWeapon == 0) { currentfirstCooldown = currentWeapon.cooldown; cooldown.maxCooldownFirstWeapon = currentWeapon.cooldown; }
                        else { currentsecondCooldown = currentWeapon.cooldown; cooldown.maxCooldownSecondWeapon = currentWeapon.cooldown; }
                    }

                    break;


                default:
                    Debug.Log("none");
                    break;

            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && movement.movementrestriction == false && movement.boosted == false && inComboAttack == true) attackQueuedUp = true;

        if (Input.GetKeyDown(KeyCode.Mouse1) && movement.movementrestriction == false && movement.boosted == false && movement.attackrestriction == false)
        {
            switch (currentWeapon.type)
            {
                case WeaponData.Type.Hammer:
                    if (!specialReady) break;

                    cooldown.maxCooldownSpecialofWeapon = currentWeapon.specialcooldown;
                    animator.SetTrigger("earthwallhammer"); movement.attackrestriction = true; specialWeaponCooldown = currentWeapon.specialcooldown;
                    break;

                case WeaponData.Type.Sword:
                    if (!specialReady) break;
                    cooldown.maxCooldownSpecialofWeapon = currentWeapon.specialcooldown;
                    restrictions.currentAttackRange = 0.8f;
                    animator.SetTrigger("SwordgarenSpecial"); specialWeaponCooldown = currentWeapon.specialcooldown;
                    break;
            }


        }
    }

}
