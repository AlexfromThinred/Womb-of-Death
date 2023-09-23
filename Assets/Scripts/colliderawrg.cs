using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderawrg : MonoBehaviour
{


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("aswrf");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Buggy as hell");
    }
}
