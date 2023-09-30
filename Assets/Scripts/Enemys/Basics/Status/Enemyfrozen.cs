using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyfrozen : MonoBehaviour
{
    public Animator animator;
    public Moveenemy enemymove;

   
    public void Resettriggerfreeze()
    {
        animator.SetBool("isfrozen", false);
        enemymove.frozen = false;
    }

    public void Hideobject()
    {
       gameObject.SetActive(false);
    }
}
