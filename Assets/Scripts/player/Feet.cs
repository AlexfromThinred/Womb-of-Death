using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public Movement movement;
    public Collider2D coll;

    public void Start()
    {
        coll = GetComponent<Collider2D>();

       
    }

    public void Update()
    {
        
    }

    

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (Physics2D.BoxCast(coll.bounds.center, coll.bounds.size - new Vector3(0.001f, 0, 0), 0f, Vector2.down, .1f) == true && collision.CompareTag("ground") == true)
        {
            movement.grounded = true;
        }
        //  if (collision.CompareTag("ground") == true) movement.grounded = true;
        //   else movement.grounded = false;


        // else movement.grounded = false;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {

        if (Physics2D.BoxCast(coll.bounds.center, coll.bounds.size - new Vector3(0.001f, 0, 0), 0f, Vector2.down, .1f) == true && collision.CompareTag("ground") == true) 
        {
         movement.grounded = true;
        }
       // else movement.grounded = false;

       // if (collision.CompareTag("ground") == true) movement.grounded = true;
       // else movement.grounded = false;
        // || movement.yeet.velocity.y == 0

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (Physics2D.BoxCast(coll.bounds.center, coll.bounds.size - new Vector3(0.001f, 0, 0), 0f, Vector2.down, .1f) == true && collision.CompareTag("ground") == true)
        {
            movement.grounded = false;
        }


    }


}
