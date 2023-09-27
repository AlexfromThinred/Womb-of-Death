using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveWeaponButtonLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public int weaponSlot;
    public WeaponData weapon;
    Memory memory;
    GameObject player;
    // Wenn man das anders definiert zieht er sich Unity.Engine.UIElements; damit funktioniert der Code nicht
    public UnityEngine.UI.Image oldImage;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        memory = player.GetComponent<Memory>();
        oldImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        oldImage.sprite = memory.activeWeapons[weaponSlot].sprite;
    }
}
