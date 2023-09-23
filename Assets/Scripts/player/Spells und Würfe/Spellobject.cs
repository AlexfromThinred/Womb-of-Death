using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Spell", menuName = "Inventory/Spell")]


public class Spellobject : ScriptableObject
{
    public float spellcooldown;
    public bool setsyoustill;
    public string animationtriggerword;
    public int damage;

    public float xmovement, ymovement;

    public string spellName = "New Spell";
    public string spellDescription = "New Description";


}
