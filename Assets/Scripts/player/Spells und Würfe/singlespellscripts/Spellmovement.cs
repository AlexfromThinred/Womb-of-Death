using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellmovement : MonoBehaviour
{
    public bool goestoleft;

    public Spellobject spell;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!goestoleft)
        transform.position = transform.position + new Vector3(spell.xmovement,spell.ymovement,0);  
        else transform.position = transform.position + new Vector3(-spell.xmovement, spell.ymovement, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //enemycollision. Get Healthscript of enemy and apply damage with spell.damage
    }
}
