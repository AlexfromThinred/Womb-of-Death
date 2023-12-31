using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noticingplayer : MonoBehaviour
{
    public Moveenemy move;
    public Foggrump grump;
    void Start()
    {
       
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            move.noticedPlayer = true;
            grump.anim.SetBool("Notice", true);
          

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            move.noticedPlayer = false;
            grump.anim.SetBool("Notice", false);
            Debug.Log("gone");
        }
    }
}
