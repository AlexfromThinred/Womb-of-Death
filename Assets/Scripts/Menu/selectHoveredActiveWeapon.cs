using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectHoveredActiveWeapon : MonoBehaviour
{
    WeaponData weaponData;
    void Start()
    {
        weaponData = GetComponentInChildren<ActiveWeaponButtonLogic>().weapon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void selectWeapon()
    {

    }
}
