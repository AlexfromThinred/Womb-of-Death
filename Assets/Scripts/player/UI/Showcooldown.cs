using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Showcooldown : MonoBehaviour
{
    public Image weaponCooldown;
    public Image weaponSecondCooldown;
    public Image specialCooldown;
    public Image spellCooldown;


    public Image firstweaponBackgroundImage;
    public Image specialBackgroundImage;
    public Image spellBackgroundImage;
    public Image secondBackground;

    public GameObject grayFirstWeapon;
    public GameObject graySecondWeapon;

    public Attack attack;
    public Spells spell;
    public Memory memory;

    public float maxCooldownFirstWeapon;
    public float maxCooldownSecondWeapon;
    public float maxCooldownSpecialofWeapon;
    public float maxCooldownSpell;
   

    // Start is called before the first frame update
    void Start()
    {
        attack = FindAnyObjectByType<Attack>();
        spell = FindAnyObjectByType<Spells>();
        memory = FindAnyObjectByType<Memory>();
        spellCooldown.fillAmount = 0;
        weaponCooldown.fillAmount = 0;
        weaponSecondCooldown.fillAmount = 0;
        specialCooldown.fillAmount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        firstweaponBackgroundImage.sprite = memory.activeWeapons[0].sprite;
        secondBackground.sprite = memory.activeWeapons[1].sprite;
        specialBackgroundImage.sprite = memory.currentWeaponData.specialSprite;
        spellBackgroundImage.sprite = spell.spellobject.sprite;


        if(memory.activeWeapon == 1)
        {
            grayFirstWeapon.SetActive(true);
            graySecondWeapon.SetActive(false);
        }
        else
        {
            grayFirstWeapon.SetActive(false);
            graySecondWeapon.SetActive(true);
        }

        spellCooldown.fillAmount = spell.currentcooldown / maxCooldownSpell;
        weaponCooldown.fillAmount = attack.currentfirstCooldown / maxCooldownFirstWeapon;
        weaponSecondCooldown.fillAmount = attack.currentsecondCooldown / maxCooldownSecondWeapon;
        specialCooldown.fillAmount = attack.specialWeaponCooldown / maxCooldownSpecialofWeapon;
        
    }
}
