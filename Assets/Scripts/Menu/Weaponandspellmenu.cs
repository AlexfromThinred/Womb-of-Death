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
        if (Input.GetKeyDown(KeyCode.I) && canvas.enabled == true)
        {
            canvas.enabled = false;
            Time.timeScale = 1;
            
        } else if(Input.GetKeyDown(KeyCode.I) && canvas.enabled == false)
        {
            Time.timeScale = 0;
            canvas.enabled = true;

        }
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
