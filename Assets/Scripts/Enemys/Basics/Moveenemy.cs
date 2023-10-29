using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveenemy : MonoBehaviour
{
    public Rigidbody2D body;
    public float enemyspeed, enemymaxspeed, enemyAcceleration;
    private bool isgoingleft;
    public float isstillstaggrered;
    public bool grounded;
    public bool cannotBeKnockedBack;
    public bool frozen;
    public SpriteRenderer freeze;
    public Damageontouch touchdamage;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cannotBeKnockedBack = false;
       // freeze = GetComponentInChildren<SpriteRenderer>();
    }

   public void Knockbackafterattack(float x, float y, bool knocktoleft)
    {
        if(cannotBeKnockedBack == false)
        {
            if (knocktoleft == true)
            {
                body.velocity = new Vector2(-x, y);
            }
            else body.velocity = new Vector2(x, y);

            isstillstaggrered = 0;

        }
    

    }

    public void gettingfotzen() { frozen = true; freeze.gameObject.SetActive(true); }
    void FixedUpdate()
    {
        if (frozen)
        {
            body.bodyType = RigidbodyType2D.Static;
          
            freeze.gameObject.GetComponent<Animator>().SetBool("isfrozen",true);
        }
        else
        {
            body.bodyType = RigidbodyType2D.Dynamic;
            
        }


        
        isstillstaggrered += Time.deltaTime;
        if (isstillstaggrered > 0.5f && !frozen)
        {
            if (isgoingleft == true)
                enemyspeed -= enemyAcceleration;
            else enemymaxspeed += enemyAcceleration;
            Mathf.Clamp(enemyspeed, -enemymaxspeed, enemymaxspeed);

            body.velocity = new Vector2(enemyspeed, body.velocity.y);

         
        } 
           
    }

    public void changedirection()
    {
        isgoingleft = true;
        gameObject.transform.localScale = new Vector2(-3f, 3);
        enemyspeed = -enemyspeed;
    }
}
