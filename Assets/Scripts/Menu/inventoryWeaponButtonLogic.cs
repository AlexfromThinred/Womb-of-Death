using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWeaponButtonLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public int weaponSlot;
    public WeaponData weapon;
    public bool isActive;
    Memory memory;
    GameObject player;
    // Wenn man das anders definiert zieht er sich Unity.Engine.UIElements; damit funktioniert der Code nicht
    public UnityEngine.UI.Image oldImage;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        memory = player.GetComponent<Memory>();
        oldImage = GetComponent<Image>();
        // aktuell nur manuell hinzufügbar, legt Silhoutte fest; muss im fertigen Code geändert werden
        oldImage.sprite = weapon.sprite;
        oldImage.color = Color.black;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (memory.inventory.Contains(weapon))
        {
            oldImage.color = Color.white;
            isActive = true;
        }
    }
}
