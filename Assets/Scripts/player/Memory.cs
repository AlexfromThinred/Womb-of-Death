using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Memory : MonoBehaviour
{
    public string currentItem;
    public WeaponData currentWeaponData;

    void Start()
    {
     currentItem = "none";
    }
    // Update is called once per frame
     void Update()
     {
      
     }
    public void weaponPickup(WeaponData weaponData)
    {
        currentItem = weaponData.weaponName;
        currentWeaponData = weaponData;
    }
}