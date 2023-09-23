using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealth : MonoBehaviour
{


    public int playerhealth;
    public int maxhealth;
    public void Awake()
    {
        Mathf.Clamp(playerhealth, 0, maxhealth);
    }


    public void takedamage(int amount)
    {
        playerhealth -= amount;
       // if (playerhealth <= 0) startlosingsequence();
    }






    public void Healplayer(int amount)
    {
        playerhealth += amount;

    }
}
