using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellmovement : MonoBehaviour
{
    public bool goestoleft;

    public Spellobject spell;
    public new SpriteRenderer renderer;


    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (!goestoleft)
            transform.position = transform.position + new Vector3(spell.xmovement, spell.ymovement, 0);
        else { transform.position = transform.position + new Vector3(-spell.xmovement, spell.ymovement, 0); renderer.flipX = true; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(other.gameObject);

        // if (other.gameObject.GetComponent<Enemyhealth>() == null) { Debug.Log("no enemy"); return; }


        Debug.Log(spell.damage);
        //  other.GetComponent<Enemyhealth>().dealdamage(spell.damage);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("aweergawgwgeagaqehrtawh");

    }
}
