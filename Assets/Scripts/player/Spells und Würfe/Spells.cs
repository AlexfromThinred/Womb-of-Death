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

    public Movement movement;

    void Start()
    {
     
        cancast = true;
        getspellinfos(spellobject);
   

    }

    public void managecooldown()
    {
        if (cancast == false) currentcooldown += Time.deltaTime;
        if (currentcooldown >= cooldown) { cancast = true; currentcooldown = 0; }
    }

   
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.R) && cancast == true && movement.attackrestriction == false)
        {
            Usespell(spellobject);

        }
        managecooldown();

    }

    public void Usespell(Spellobject spell)
    {
      
        Debug.Log(wordforanomationtrigger);
        animator.SetTrigger(wordforanomationtrigger);
        cancast = false;
        if (spell.setsyoustill == true) movement.movementrestriction = true;
        if(movement.boosted == false)
        movement.yeet.velocity = new Vector2(0,0);
       
       

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
}
