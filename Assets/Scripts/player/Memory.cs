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
    public List<GameObject> knownRunesstones = new List<GameObject>();
    public WeaponData[] activeWeapons = new WeaponData[2];
    public int activeWeapon = 0;
    public WeaponData noWeapon;


    public bool swordgroundshockwave;

    public bool lightningstrike;
    public bool lightningstrikeHammer;
    public bool earthstabhammer;
    public bool tidalWave;
    public bool fireslash;
    public bool airDrill;

    void Start()
    {
        swordgroundshockwave = true;
        lightningstrike = true;
        lightningstrikeHammer = true;
        earthstabhammer = true;
        tidalWave = true;
        fireslash = true;
        airDrill = true;
    }
    // Update is called once per frame
     void Update()
     {
      if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (activeWeapon == 0 && activeWeapons[1] != null)
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
    // Stuff that happens, when weapon gets picked up
    public void weaponPickup(WeaponData newWeaponData)
    {
        if (!inventory.Contains(newWeaponData))
        {
            inventory.Add(newWeaponData);
        }
        // Equip Weapon, when no weapon held
        if (activeWeapons[0] == null || activeWeapons[0] == noWeapon)
        {
            activeWeapons[0] = newWeaponData;
            currentWeaponData = newWeaponData;
        } else if (activeWeapons[1] == null || activeWeapons[1] == noWeapon)
        {
            activeWeapons[1] = newWeaponData;
        }
    }
}