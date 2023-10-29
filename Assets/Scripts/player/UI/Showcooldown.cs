using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Showcooldown : MonoBehaviour
{
    public Image weaponCooldown;
    public Attack attack;
    public Image bowCooldown;
    public Image spellCooldown;
    public Spells spell;

    // Start is called before the first frame update
    void Start()
    {
        attack = FindAnyObjectByType<Attack>();
        spell = FindAnyObjectByType<Spells>();
    }

    // Update is called once per frame
    void Update()
    {
        weaponCooldown.fillAmount = attack.currentMeeleCooldown / 2;
        bowCooldown.fillAmount = attack.currentRangedCooldown / 2;
        spellCooldown.fillAmount = spell.currentcooldown / 5;
    }
}
