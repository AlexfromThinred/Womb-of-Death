using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public Spellobject spellobject;

    public GameObject obj;

    public Animator animator;
    public float cooldown;
    public float currentcooldown;
    public bool cancast;
    public string wordforanomationtrigger;

    public Movement movement;

    void Start()
    {
        // animator
        cancast = true;
        getspellinfos(spellobject);
   

    }

    public void managecooldown()
    {
        if (cancast == false) currentcooldown += Time.deltaTime;
        if (currentcooldown >= cooldown) { cancast = true; currentcooldown = 0; }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.R) && cancast == true)
        {
            Usespell(spellobject);

        }
        managecooldown();

    }

    public void Usespell(Spellobject spell)
    {
        // Instantiate oder animator.gettrigger to start animation and use own function
        Debug.Log(wordforanomationtrigger);
        animator.SetTrigger(wordforanomationtrigger);
        cancast = false;
        if (spell.setsyoustill == true) movement.movementrestriction = true;


    }

    public void getspellinfos(Spellobject spell)
    {
        cooldown = spell.spellcooldown;
        wordforanomationtrigger = spell.animationtriggerword;
        



    }

    public void resetthetrigger()
    {
        animator.ResetTrigger(wordforanomationtrigger);
    }

    public void resetmovementrestriction()
    {
        movement.movementrestriction = false;
    }

    public  void instanspell()
    {
        var fireball = Instantiate(obj, new Vector3(movement.transform.localPosition.x, movement.transform.localPosition.y + 1, 0), Quaternion.identity);
        if( movement.GetComponent<RectTransform>().localScale.x < 0) fireball.GetComponent<Spellmovement>().goestoleft = true;

    }

}
