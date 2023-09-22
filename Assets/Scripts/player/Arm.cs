 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public Movement movement;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("wall") == true)
        {
            movement.xMin = -0.004f;
            movement.xMax = 0.004f;
         
            movement.isonwall = true;
        }
            


    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("wall") == true)
        {
            movement.xMax = 2f;
            movement.xMin = -2f;
            movement.isonwall = false;
        }


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("weapon") == true)
        {
            GetComponentInParent<Memory>().weaponPickup(collision.gameObject.GetComponent<CollectWeapon>().weaponData);
            Destroy(collision.gameObject);
        }
    }
}
