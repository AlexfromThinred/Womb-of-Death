using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectHoveredActiveWeapon : MonoBehaviour
{
    public int selectedSlot;
    void Start()
    {
        selectedSlot = GetComponentInChildren<ActiveWeaponButtonLogic>().weaponSlot;
    }
    public void selectSlot()
    {
        GetComponentInParent<HoveredSlot>().hoveredSlot = selectedSlot;
    }
}
