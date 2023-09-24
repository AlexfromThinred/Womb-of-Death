 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public Movement movement;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<isawall>() != null)
        {
       
         
            movement.isonwall = true;
        }
            


    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<isawall>() != null)
        {
        
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
