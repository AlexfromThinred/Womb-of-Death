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

    public Audiomanager audioManager;
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
    public bool hasdoublejump;
   
    void Start()
    {
        audioManager = FindObjectOfType<Audiomanager>();
        attackrestriction = false;
        attackrestrictionwithgravity = false;
        movementrestriction = false;
        animator = GetComponentInChildren<Animator>();
        playercollider = GetComponent<BoxCollider2D>();
        yeet = GetComponent<Rigidbody2D>();
        gravitymultiplier = -0.5f;
        jumpspeed = 10f;
        walljumpspeed = 6f;
        xMin = -3.6f - playermovementspeedbuff; xMax = 3.6f + playermovementspeedbuff;
        isonwall = false;
        ispropelling = false;
    }

    public void Update()
    {
        if (movementrestriction == false)
        {
            if (attackrestriction == false)
            {
                if (grounded && Input.GetKey(KeyCode.Space)) jump(); else if (!grounded && Input.GetKeyDown(KeyCode.Space) && isonwall) walljump(); else if (!grounded && Input.GetKeyDown(KeyCode.Space) && hasdoublejump) {  jump(); hasdoublejump = false; }

            }
        }

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

                #region Movement basics
                // resets Dash movementspeed buff

                if (grounded && boosted == false || isonwall) playermovementspeedbuff = 0;
                // Jumping or Walljumping

                
                // instantly stay still when on ground and not moving
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


                #endregion

                #region Jumpscript




                if (yeet.velocity.y < -0.2)
                {
                 
                    animator.ResetTrigger("Jump");
                    yeet.velocity += 0.54f * Vector2.down;
                }
                else if ( yeet.velocity.y > 0.45 && !Input.GetKey(KeyCode.Space) && isjumping == false)
                    {
                        yeet.velocity += Vector2.up * Physics2D.gravity.y * 0.085f;

                    }
                else
                {
                    yeet.velocity += Vector2.up * Physics2D.gravity.y * 0.008f;
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

            #endregion


        }
        else  yeet.gravityScale = 0;  
        

    }


    

 
    public void jump()
    {
        audioManager.Play("Jumpaudios");
        animator.ResetTrigger("Jump");
        animator.SetTrigger("Jump");
        isjumping = true;
        playerymov = jumpspeed;
        Vector2 jumpvelocity = new Vector2(playermovementspeed, playerymov);
        yeet.velocity = jumpvelocity;
        StartCoroutine(MinJump());
        grounded = false;


    }

   
    private IEnumerator MinJump()
    {
        yield return new WaitForSeconds(0.08f);
        isjumping = false;
    }
   


    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.24f);
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
