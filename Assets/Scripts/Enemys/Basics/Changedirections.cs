using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changedirections : MonoBehaviour
{
    public Moveenemy move;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        move.changedirection();
    }



}
