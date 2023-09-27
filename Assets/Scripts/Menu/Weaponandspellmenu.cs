using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponandspellmenu : MonoBehaviour
{
    public Canvas canvas;

    public GameObject Spellmenu;
    public GameObject Weaponmenu;
    public void Awake()
    {
        
        canvas = GetComponent<Canvas>();
        Spellmenu.SetActive(false);
        canvas.enabled = false;

    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void openMenu()
    {
        Time.timeScale = 0;
        canvas.enabled = true;
    }
    public void closeMenu()
    {
        Time.timeScale = 1;
        canvas.enabled = false;
    }

    public void openSpells()
    {
        Weaponmenu.SetActive(false);
        Spellmenu.SetActive(true);
    }

    public void openweapons()
    {
        Spellmenu.SetActive(false);
        Weaponmenu.SetActive(true);
     
    }




}
