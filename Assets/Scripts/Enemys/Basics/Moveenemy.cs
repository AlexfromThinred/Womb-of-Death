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

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cannotBeKnockedBack = false;
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
    void Update()
    {
        isstillstaggrered += Time.deltaTime;
        if (isstillstaggrered > 0.5f)
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
