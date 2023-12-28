using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Spells : MonoBehaviour
{
    public Spellobject spellobject;

    public GameObject obj;

    public Animator animator;
    public float cooldown;
    public float currentcooldown;
    public bool cancast;
    public string wordforanomationtrigger;
    public bool instantiateAtMouse;
    public Movement movement;
    public Vector3 screenposition;
    public Vector3 worldposition;
    public bool bufferedspell;

    void Start()
    {
     
        cancast = true;
        getspellinfos(spellobject);
        managecooldown();

    }

    public void managecooldown()
    {
        if (cancast == false) currentcooldown -= Time.deltaTime;
        if (currentcooldown <= 0) { cancast = true; currentcooldown = 0; }
    }

   
    void Update()
    {
        
        

        if(bufferedspell == true && movement.attackrestriction == false)
        {
            Usespell(spellobject);
            bufferedspell = false;

        }else if (Input.GetKeyDown(KeyCode.R) && cancast == true && movement.attackrestriction == false)
        {
            Usespell(spellobject);

        }
        else if (Input.GetKeyDown(KeyCode.R) && cancast == true) bufferedspell = true;


        managecooldown();

    }

    public void Usespell(Spellobject spell)
    {
        currentcooldown = cooldown;
   
        if(instantiateAtMouse == false)
        animator.SetTrigger(wordforanomationtrigger);

        cancast = false;

        if (spell.setsyoustill == true) movement.movementrestriction = true;

        if(movement.boosted == false)

        movement.yeet.velocity = new Vector2(0,0);

        movement.yeet.gravityScale = 1f;

        if (instantiateAtMouse)
        {
            screenposition = Input.mousePosition;
            worldposition = Camera.main.ScreenToWorldPoint(screenposition);
            instanspellatMouseposition(worldposition);
        }
    }

    public void getspellinfos(Spellobject spell)
    {
        cooldown = spell.spellcooldown;
        wordforanomationtrigger = spell.animationtriggerword;
        instantiateAtMouse = spell.looksAtMouse;
        obj = spell.spellObj;


    }

    public void resetthetrigger()
    {
        animator.ResetTrigger(wordforanomationtrigger);
    }

    public void resetmovementrestriction()
    {
        
        movement.movementrestriction = false;
        movement.yeet.gravityScale = 0.65f;

        
    }
    public void resetmovementrestriction2()
    {

        movement.movementrestriction = false;
        movement.yeet.gravityScale = 0.65f;


    }

    public  void instanspell()
    {
        var fireball = Instantiate(obj, new Vector3(movement.transform.localPosition.x, movement.transform.localPosition.y, 0), Quaternion.identity);
        if( movement.GetComponent<RectTransform>().localScale.x < 0) fireball.GetComponent<Spellmovement>().goestoleft = true;

    }

   public void pushback(AnimationEvent animation)
    {
        float x = animation.floatParameter;
            int y = animation.intParameter;
      

        if (movement.transform.localScale.x < 1f)
        {
            movement.yeet.velocity = new Vector2(x, y);
            movement.playermovementspeed = 3f;
        }
        else
        {
            movement.yeet.velocity = new Vector2(-x, y);
            movement.playermovementspeed = -3f;
        }

       
    }
    public void instanspellatMouseposition(Vector3 pos)
    {
        var Spell = Instantiate(obj, new Vector3(pos.x, pos.y, -2), Quaternion.identity);
      

    }
}
