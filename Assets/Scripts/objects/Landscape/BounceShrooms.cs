using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceShrooms : MonoBehaviour
{
    public float bounceStrength;
    public Animator animator;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>() != null)
        {
            Rigidbody2D vel = collision.GetComponent<Movement>().yeet;
            vel.velocity = new Vector2(vel.velocity.x, bounceStrength);
            animator.SetTrigger("bounce");

        } else if (collision.GetComponent<Moveenemy>() != null)
            {
            collision.GetComponent<Moveenemy>().Knockbackafterattack(0, bounceStrength-2, false);
            animator.SetTrigger("bounce");
        }
    }
}
