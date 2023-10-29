using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool grounded;
    public bool isonwall;
    public bool ispropelling;
    public float propelltime;
    public bool boosted;
    public bool attackrestriction;
    public bool attackrestrictionwithgravity;

    public float currentpropelltime;
    public bool isgoingtoleft;

    public Animator animator;

    public float playermovementspeed;
    public float playermovementspeedbuff = 0;
    public bool movementrestriction;


    public Rigidbody2D yeet;
    public float jumpspeed;
    public float walljumpspeed;
    public float gravitymultiplier;
    Collider2D playercollider;
    public float xMin, xMax;
    float playerymov;
    Collider2D feet;
    public bool canattack;

    public bool isjumping;

   
    void Start()
    {
        attackrestriction = false;
        attackrestrictionwithgravity = false;
        movementrestriction = false;
        animator = GetComponentInChildren<Animator>();
        playercollider = GetComponent<BoxCollider2D>();
        yeet = GetComponent<Rigidbody2D>();
        gravitymultiplier = -0.5f;
        jumpspeed = 7f;
        walljumpspeed = 5.5f;
        xMin = -3.6f - playermovementspeedbuff; xMax = 3.6f + playermovementspeedbuff;
        isonwall = false;
        ispropelling = false;
    }
   


    void FixedUpdate()
    {
        Mathf.Clamp(yeet.velocity.y, -17, 20);
        xMin = -3.6f - playermovementspeedbuff; xMax = 3.6f + playermovementspeedbuff;
        if (boosted == true)
        {
            if (gameObject.transform.localScale.x < 1f) { playermovementspeed = -3.6f - playermovementspeedbuff; }
            else playermovementspeed = 3.6f + playermovementspeedbuff;
            yeet.velocity = new Vector2(playermovementspeed, 0f);
        }

        
        if (movementrestriction == false)
        {
            if(attackrestriction == false )
            {
                if (grounded && boosted == false || isonwall) playermovementspeedbuff = 0;

              

                if (grounded && Input.GetKey(KeyCode.Space)) jump(); else if (!grounded && Input.GetKey(KeyCode.Space) && isonwall && !ispropelling) walljump();

               
               



                if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && grounded == true) { playermovementspeed = 0; }





                if (Input.GetKey(KeyCode.D) && ispropelling == false && boosted == false)
                {
                    if(yeet.velocity.x < 0) playermovementspeed += 0.4f + playermovementspeedbuff;


                    playermovementspeed += 0.23f + playermovementspeedbuff;
                }

                if (Input.GetKey(KeyCode.A) && ispropelling == false && boosted == false)
                {
                    if (yeet.velocity.x > 0) playermovementspeed -= 0.4f + playermovementspeedbuff;
                    playermovementspeed -= 0.23f + playermovementspeedbuff;
                }


                if (ispropelling == true)
                {


                    if (isgoingtoleft == true) { playermovementspeed = -3.6f - playermovementspeedbuff; }
                    else
                    {
                        playermovementspeed = 3.6f + playermovementspeedbuff;

                    }

                }



                playermovementspeed = Mathf.Clamp(playermovementspeed, xMin, xMax);

                Vector2 pvelocity = new Vector2(playermovementspeed, yeet.velocity.y);
                yeet.velocity = pvelocity;
                if (playermovementspeed > 0) transform.localScale = new Vector2(3, 3);
                if (playermovementspeed < 0) transform.localScale = new Vector2(-3, 3);

                
                if (yeet.velocity.y < -0.2)
                {
                 
                    animator.ResetTrigger("Jump");
                    yeet.velocity += 0.49f * Vector2.down;
                }
                else if ( yeet.velocity.y > 0.45 && !Input.GetKey(KeyCode.Space) && isjumping == false)
                    {
                        yeet.velocity += Vector2.up * Physics2D.gravity.y * 0.085f;

                    }

                if (yeet.velocity.y <= 1.5 && isjumping)
                {
                    yeet.velocity += Vector2.up * Physics2D.gravity.y * 0.18f;
                   
                }






                if (yeet.velocity.y > 0) animator.SetBool("acceleratedown", false); else animator.SetBool("acceleratedown", true);

                if (grounded) animator.SetBool("isgrounded", true); else animator.SetBool("isgrounded", false);
               


                if (grounded && playermovementspeed != 0) animator.SetBool("walking", true); else animator.SetBool("walking", false);

            } else if (attackrestrictionwithgravity == true)
            {
                if (yeet.velocity.y < -0.3f)
                {
                    isjumping = false;
                    animator.ResetTrigger("Jump");
                    yeet.velocity += 0.5f * Vector2.down;

                }
            }
            

        }
        else  yeet.gravityScale = 0;  
        

    }


    

 
    public void jump()
    {
        isjumping = true;
        animator.SetTrigger("Jump");    
        playerymov = jumpspeed;
        Vector2 jumpvelocity = new Vector2(playermovementspeed, playerymov);
        yeet.velocity = jumpvelocity;
        grounded = false;

        StartCoroutine(MinJump());
    }
    private IEnumerator MinJump()
    {
        yield return new WaitForSeconds(0.27f);
        isjumping = false;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        ispropelling = false;
    }


    public void walljump()
    {
        if (playermovementspeed > 0) { playermovementspeed = -3f; isgoingtoleft = true;  } else if (playermovementspeed < 0) { playermovementspeed = 3f; isgoingtoleft = false; }
        ispropelling = true;
        playerymov = walljumpspeed;
        Vector2 jumpvelocity = new Vector2(playermovementspeed, playerymov);
        yeet.velocity = jumpvelocity;
        StartCoroutine(Wait());
    }
}
