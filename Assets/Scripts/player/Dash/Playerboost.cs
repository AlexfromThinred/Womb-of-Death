using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerboost : MonoBehaviour
{

     Movement movement;
    public float boostspeed;
    public bool ready;
    public bool candashup;
    public bool dashqueuedup;
    public float lastImageXPos, distanceBetweenImages;

    public void Awake()
    {
     
        movement = GetComponent<Movement>();
        ready = true;
        dashqueuedup = false;
    }

    // Update is called once per frame




    void Update()
    {
        if (movement.boosted == true) checkafterimages();
        if (movement.movementrestriction == false && ready && dashqueuedup)
        {
            Debug.Log("boost"); movement.playermovementspeedbuff = 6f; 
            StartCoroutine(boosttime()); 
            movement.boosted = true; 
            dashqueuedup = false;
            ready = false;
            return; 
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && ready && movement.movementrestriction == false) { Debug.Log("boost"); movement.playermovementspeedbuff = 6f; StartCoroutine(boosttime()); 
            movement.boosted = true;
            ready = false;
        }


        else if (Input.GetKeyDown(KeyCode.LeftShift) && ready && movement.movementrestriction == true) dashqueuedup = true;
    }

   

    public void checkafterimages()
    {
      if (Mathf.Abs(transform.position.x - lastImageXPos) > distanceBetweenImages)
        {
            Afterimagepool.instance.pullfromPool();
            lastImageXPos = transform.position.x;
        }
        
      if(movement.isonwall == true)
        {
            movement.boosted = false;
            movement.playermovementspeedbuff = 0f;
        }

    }
        IEnumerator boosttime()
    {

        yield return new WaitForSeconds(0.3f);
       
        movement.boosted = false;
        movement.playermovementspeedbuff = 0f;
        StartCoroutine(dashcooldown());

    }

    IEnumerator dashcooldown()
    {
        yield return new WaitForSeconds(1.3f);
        ready = true;
    }
}
