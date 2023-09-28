using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public Movement movement;

   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground") == true) movement.grounded = true;
        else movement.grounded = false;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ground") == true) movement.grounded = true;
       // else movement.grounded = false;
        // || movement.yeet.velocity.y == 0

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
      //  if (collision.CompareTag("ground") == true)
       movement.grounded = false;
    

    }


}
