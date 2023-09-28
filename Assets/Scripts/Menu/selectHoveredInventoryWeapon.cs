using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectHoveredInventoryWeapon : MonoBehaviour
{
    public WeaponData weaponData;
    void Start()
    {
        weaponData = GetComponentInChildren<InventoryWeaponButtonLogic>().weapon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void selectWeapon()
    {
        Debug.Log("Halloo!");
        if (GetComponentInChildren<InventoryWeaponButtonLogic>().isActive)
        {
            GetComponentInParent<HoveredWeapon>().hoveredWeapon = weaponData;
            // Invoke Weapon Change
        }
    }
}
