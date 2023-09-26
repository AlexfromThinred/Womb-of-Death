using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public WeaponData currentWeapon;
    public bool canMeeleAttack;
    public bool canRangedAttack;
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
        currentWeapon = GetComponent<Memory>().currentWeaponData;
        if (Input.GetKeyDown(KeyCode.Mouse0) && movement.movementrestriction == false && movement.boosted == false && movement.attackrestriction == false) { 
            switch(currentWeapon.type)
            {
                case WeaponData.Type.Bow: Debug.Log("Bow");
                    // Bow Default Attack
                     var projectile = Instantiate(arrow, new Vector3(gameObject.transform.localPosition.x,gameObject.transform.localPosition.y, 0), 
                         Quaternion.Euler(0f, 0f, (Mathf.Atan2(Input.mousePosition.y - Camera.main.WorldToScreenPoint(gameObject.transform.localPosition).y, Input.mousePosition.x - Camera.main.WorldToScreenPoint(gameObject.transform.localPosition).x) * Mathf.Rad2Deg)));
                   break;
                case WeaponData.Type.Sword:

                    Debug.Log("Sword");
                    //trigger
                    inComboAttack = true;
                    if (Input.GetKey(KeyCode.W) && movement.grounded == true) { animator.SetTrigger("swordattackup"); } 
                    else if (Input.GetKey(KeyCode.S) && movement.grounded == false) animator.SetTrigger("swordattackdown"); 
                    else
                    {
                        inComboAttack = true;
                        animator.SetTrigger("swordattack");
                    }
                   

                    break;
                case WeaponData.Type.Daggers:
                    // Dagger Attack Code
                    Debug.Log("Dagger");
                    break;
                default: Debug.Log("none");
                   break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && movement.movementrestriction == false && movement.boosted == false && inComboAttack == true) attackQueuedUp = true;






    }
}
