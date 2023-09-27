using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponButtonLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public int weaponSlot;
    public WeaponData weapon;
    public Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeActiveWeaponImage(WeaponData newWeapon)
    {
        image.sprite = newWeapon.sprite;
    }
}
