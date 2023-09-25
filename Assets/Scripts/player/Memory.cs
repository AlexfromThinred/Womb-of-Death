using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Memory : MonoBehaviour
{
    public WeaponData currentWeaponData;
    public List<WeaponData> inventory = new List<WeaponData>();
    public WeaponData[] activeWeapons = new WeaponData[2];
    public int activeWeapon = 0;

    void Start()
    {

    }
    // Update is called once per frame
     void Update()
     {
      if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (activeWeapon == 0)
            {
                currentWeaponData = activeWeapons[1];
                activeWeapon = 1;
            } else if (activeWeapon == 1)
            {
                currentWeaponData = activeWeapons[0];
                activeWeapon = 0;
            }
            
        }
     }
    public void weaponPickup(WeaponData weaponData)
    {
        currentWeaponData = weaponData;
        inventory.Add(currentWeaponData); 
        if (activeWeapons[0] == null)
        {
            activeWeapons[0] = weaponData;
        } else if (activeWeapons[1] == null)
        {
            activeWeapons[1] = weaponData;
        }
    }
}