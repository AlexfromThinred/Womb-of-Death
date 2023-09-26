using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public WeaponData currentWeapon;
    public bool meleeAttackReady;
    public bool rangedAttackReady;
    public bool comboAttacks;
    public bool attackQueuedUp;
    public bool inComboAttack;
    public float currentRangedCooldown;
    public float currentMeeleCooldown;
    public GameObject arrow;
    public GameObject swing;
    public Animator animator;
    public Movement movement;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        movement = GetComponent<Movement>();
    }


    

    // Update is called once per frame
    void Update()
    {
        meleeAttackReady = (currentMeeleCooldown <= 0);
        rangedAttackReady = (currentRangedCooldown <= 0);
        currentWeapon = GetComponent<Memory>().currentWeaponData;
        if (currentRangedCooldown > 0 && currentWeapon.weaponType == WeaponData.WeaponType.Ranged)
        {
            currentRangedCooldown -= Time.deltaTime;
        }
        if (currentMeeleCooldown > 0 && currentWeapon.weaponType == WeaponData.WeaponType.Melee) {
            currentMeeleCooldown -= Time.deltaTime;
            if(currentWeapon.type == WeaponData.Type.Sword && movement.grounded && currentMeeleCooldown > currentWeapon.cooldown / 25)
            {
                currentMeeleCooldown = currentWeapon.cooldown / 25;
            }
        }



        if (Input.GetKeyDown(KeyCode.Mouse0) && movement.movementrestriction == false && movement.boosted == false && movement.attackrestriction == false) { 
            switch(currentWeapon.type)
            {
                case WeaponData.Type.Bow:
                    // Bow Default Attack
                    if(!rangedAttackReady)
                    {
                        break;
                    }
                     var projectile = Instantiate(arrow, new Vector3(gameObject.transform.localPosition.x,gameObject.transform.localPosition.y, 0), 
                         Quaternion.Euler(0f, 0f, (Mathf.Atan2(Input.mousePosition.y - Camera.main.WorldToScreenPoint(gameObject.transform.localPosition).y, Input.mousePosition.x - Camera.main.WorldToScreenPoint(gameObject.transform.localPosition).x) * Mathf.Rad2Deg)));
                    currentRangedCooldown = currentWeapon.cooldown;
                   break;



                case WeaponData.Type.Sword:

                    inComboAttack = true;
                    if (Input.GetKey(KeyCode.W) && movement.grounded == true) { animator.SetTrigger("swordattackup"); } 
                    else if (Input.GetKey(KeyCode.S) && movement.grounded == false) animator.SetTrigger("swordattackdown"); 
                    else if(meleeAttackReady)
                    {
                        inComboAttack = true;
                        animator.SetTrigger("swordattack");
                    }
                    break;



                case WeaponData.Type.Daggers:

                    // Dagger Attack Code
                    Debug.Log("Dagger");
                    if (!meleeAttackReady)
                    {
                        break;
                    }
                    if (Input.GetKey(KeyCode.S) && movement.grounded == false) { animator.SetTrigger("daggerdown"); currentMeeleCooldown = currentWeapon.cooldown * 1.8f; }
                    else if (Input.GetKey(KeyCode.W)) { animator.SetTrigger("daggerup"); currentMeeleCooldown = currentWeapon.cooldown * 1.6f; } else
                    {
                        animator.SetTrigger("daggerattack");
                        currentMeeleCooldown = currentWeapon.cooldown;
                       
                    }



                    break;
                default: Debug.Log("none");
                   break;


            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && movement.movementrestriction == false && movement.boosted == false && inComboAttack == true) attackQueuedUp = true;






    }

  
}
