using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public Movement movement;

    

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ground") == true || movement.yeet.velocity.y == 0) movement.grounded = true;
        else movement.grounded = false;
        Debug.Log(movement.grounded);
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground") == true) movement.grounded = false;
        Debug.Log(movement.grounded);

    }


}
