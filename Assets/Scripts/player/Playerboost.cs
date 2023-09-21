using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerboost : MonoBehaviour
{

     Movement movement;
    public float boostspeed;
    public bool ready;


    public void Awake()
    {
        movement = GetComponent<Movement>();
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && ready) { Debug.Log("boost"); movement.playermovementspeedbuff = 3f; StartCoroutine(boosttime()); movement.boosted = true; } 
    }


    IEnumerator boosttime()
    {

        yield return new WaitForSeconds(1f);
        movement.boosted = false;
        //  movement.playermovementspeedbuff = 0f;
    }
}
