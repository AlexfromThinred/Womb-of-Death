using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellmovement : MonoBehaviour
{
    public bool goestoleft;

    public Spellobject spell;
    public new SpriteRenderer renderer;
    public float alive;
    public bool isFire;
    public bool isWater;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        alive += Time.deltaTime;

        if (!goestoleft)
            transform.position = transform.position + new Vector3(spell.xmovement, spell.ymovement, 0);
        else { transform.position = transform.position + new Vector3(-spell.xmovement, spell.ymovement, 0); renderer.flipX = true; }

        if(alive > 1.3)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Enemyhealth>() == null) { Debug.Log("no enemy"); return; }

        if (spell.isFire) { other.GetComponent<Enemyhealth>().dealdamage(spell.damage, true, false); }
        else if (spell.isWater) { other.GetComponent<Enemyhealth>().dealdamage(spell.damage, false, true); }
        else  other.GetComponent<Enemyhealth>().dealdamage(spell.damage, false, false); 

        if (other.GetComponent<Moveenemy>() != null)
         other.GetComponent<Moveenemy>().Knockbackafterattack(spell.enemyknockbackX, spell.enemyknockbackY, goestoleft);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
