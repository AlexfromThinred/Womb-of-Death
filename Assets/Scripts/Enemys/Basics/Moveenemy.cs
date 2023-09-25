using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveenemy : MonoBehaviour
{
    public Rigidbody2D body;
    public float enemyspeed;
    private bool isgoingleft;
    public float isstillstaggrered;
    public bool grounded;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

   public void Knockbackafterattack(float x, float y, bool knocktoleft)
    {
        if(knocktoleft == true)
        {
            body.velocity = new Vector2(-x, y);
        }
        else body.velocity = new Vector2(x, y);

        isstillstaggrered = 0;


    }
    void Update()
    {
    
        if(isstillstaggrered > 0.5f )
        body.velocity = new Vector2(enemyspeed, body.velocity.y);

        isstillstaggrered += Time.deltaTime;
    }

    public void changedirection()
    {
        isgoingleft = true;
        gameObject.transform.localScale = new Vector2(-3f, 3);
        enemyspeed = -enemyspeed;
    }
}
