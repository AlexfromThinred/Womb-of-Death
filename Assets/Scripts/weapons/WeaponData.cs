using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName = "New Weapon";
    public string specialName = "New Special";
    public string itemDescription = "New Description";
    public Sprite sprite;
    public Sprite projectileSprite;
    public int damage = 0;
    public float cooldown = 1;
    public enum Type { Default, Sword, Bow }
    public Type type = Type.Default;
}
