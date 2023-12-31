using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveenemy : MonoBehaviour
{
    public bool dosentMove;
    public bool hardtoKnockedBack;
    public Rigidbody2D body;
    public bool noticedPlayer;
    public float enemyspeed, enemymaxspeed, enemyAcceleration;
    public bool isgoingleft;
    public float isstillstaggrered;
    public bool grounded;
    public bool cannotBeKnockedBack;
    public bool frozen;
    public SpriteRenderer freeze;
    public Damageontouch touchdamage;
    public bool followsplayer;
    public Transform playertransform;
    public Transform ownPosition;


    public bool isProjectile;
   
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cannotBeKnockedBack = false;
        // freeze = GetComponentInChildren<SpriteRenderer>();
        playertransform = FindFirstObjectByType<Movement>().transform;
        ownPosition = GetComponent<Transform>();
    }

   public void Knockbackafterattack(float x, float y, bool knocktoleft)
    {

        if (isProjectile == true && !cannotBeKnockedBack)
        {

            if (knocktoleft == true)
            {

                body.velocity = new Vector2(-x-5, y*1.3f);
            }
            else body.velocity = new Vector2(x+5, y * 1.3f);
          //  return;
        }
        else if (cannotBeKnockedBack == false)
        {
            if (knocktoleft == true)
            {

                body.velocity = new Vector2(-x, y);
            }
            else body.velocity = new Vector2(x, y);

            if(hardtoKnockedBack)
            {
                isstillstaggrered = 0.2f;
            } else
            isstillstaggrered = 0f;

        }
    

    }

    public void gettingfotzen() { if (!isProjectile) { frozen = true; freeze.gameObject.SetActive(true); } }
    void FixedUpdate()
    {
        if(dosentMove == false) {
        if (isgoingleft )
        {
            float scaling;
            scaling = gameObject.transform.localScale.x;
            scaling = Mathf.Abs(scaling);
            gameObject.transform.localScale = new Vector2(scaling, gameObject.transform.localScale.y);
        }
        else
        {
            float scaling;
            scaling = gameObject.transform.localScale.x;
            scaling = Mathf.Abs(scaling);
            
            gameObject.transform.localScale = new Vector2(-scaling, gameObject.transform.localScale.y);
        }
        }


        if (noticedPlayer)
        {
            if (frozen)
            {
                body.bodyType = RigidbodyType2D.Static;

                freeze.gameObject.GetComponent<Animator>().SetBool("isfrozen", true);
                return;
            }
            else
            {
                body.bodyType = RigidbodyType2D.Dynamic;

            }

            enemyspeed = Mathf.Clamp(enemyspeed, -enemymaxspeed, enemymaxspeed);
            isstillstaggrered += Time.deltaTime;



            if (followsplayer && isstillstaggrered > 0.5f && !frozen)
            {

                if (playertransform.position.x > ownPosition.position.x)
                    isgoingleft = false;
                else isgoingleft = true;



            } 
            
            if (isstillstaggrered > 0.5f && !frozen && dosentMove == false)
            {
                if (isgoingleft == true)
                    enemyspeed -= enemyAcceleration;
                else enemyspeed += enemyAcceleration;


                body.velocity = new Vector2(enemyspeed, body.velocity.y);


            } else
            {
               // enemyspeed = 0;
                //body.velocity = new Vector2(enemyspeed, body.velocity.y);
            }
        



        }

    }

    public void changedirection()
    {

        if(isgoingleft == false){
            isgoingleft = true;
            gameObject.transform.localScale = new Vector2(-gameObject.transform.localScale.x, gameObject.transform.localScale.y);
         

        }
        else
        {
            isgoingleft = false;
            gameObject.transform.localScale = new Vector2(-gameObject.transform.localScale.x, gameObject.transform.localScale.y);

        }
       
    }

  
}
