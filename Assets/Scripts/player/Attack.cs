using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public string currentWeapon;
    public bool canMeeleAttack;
    public bool canRangedAttack;
    public float currentRangedCooldown;
    public float currentMeeleCooldown;
    public GameObject arrow;
    void Start()
    {
    
    }


    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) { 
            switch(GetComponentInParent<Memory>().currentWeaponData.type)
            {
                case WeaponData.Type.Bow: Debug.Log("Bow");
                    // Bow Default Attack
                     var projectile = Instantiate(arrow, new Vector3(gameObject.transform.localPosition.x,gameObject.transform.localPosition.y, 0), 
                          Quaternion.Euler(0f, 0f, (Mathf.Atan2(Input.mousePosition.y - Camera.main.WorldToScreenPoint(gameObject.transform.localPosition).y, Input.mousePosition.x - Camera.main.WorldToScreenPoint(gameObject.transform.localPosition).x) * Mathf.Rad2Deg)));
                   break;
                default: Debug.Log("none");
                   break;
            }
        }






    }
}
