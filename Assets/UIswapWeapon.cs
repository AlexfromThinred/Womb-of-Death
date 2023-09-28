using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIswapWeapon : MonoBehaviour
{
    public Memory memory;
    GameObject player;
    public int selectedSlot;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        memory = player.GetComponent<Memory>();
        selectedSlot = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void swapWeapon()
    {
        selectedSlot = GetComponentInChildren<HoveredSlot>().hoveredSlot;
        memory.activeWeapons[selectedSlot] = GetComponentInChildren<HoveredWeapon>().hoveredWeapon;
    }
}
