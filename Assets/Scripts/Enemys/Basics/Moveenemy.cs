using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveenemy : MonoBehaviour
{
    public Rigidbody2D body;
    public float enemyspeed;
    private bool isgoingleft;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        body.velocity = new Vector2(enemyspeed, body.velocity.y);
        
    }

    public void changedirection()
    {
        isgoingleft = true;
        gameObject.transform.localScale = new Vector2(-3f, 3);
        enemyspeed = -enemyspeed;
    }
}
