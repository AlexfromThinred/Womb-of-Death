using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Runestone : MonoBehaviour
{
    GameObject player;
    public Sprite activesprite;
    bool knownRunestone = false;
    Weaponandspellmenu inventoryMenu;
    public float minimapx;
    public float minimapy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        inventoryMenu = FindObjectOfType<Weaponandspellmenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(this.transform.position, player.transform.position) < 2.5f)
        {
            // Menue oeffnen/schliessen
            if (knownRunestone)
            {
                if (!inventoryMenu.canvas.enabled)
                {
                    inventoryMenu.openMenu();
                }
                else if (inventoryMenu.canvas.enabled)
                {
                    inventoryMenu.closeMenu();
                }
            }
            if (!player.GetComponent<Memory>().knownRunesstones.Contains(this.gameObject))
            {
                // Hinzufügen der Runesstones zu den bekannten Runestones, Umwandlung in die andere Textur (Fancy Sprite + Animation benötigt)
                player.GetComponent<Memory>().knownRunesstones.Add(this.gameObject);
                GetComponent<SpriteRenderer>().sprite = activesprite;
                knownRunestone = true;
            }
            
        }
    }
}
