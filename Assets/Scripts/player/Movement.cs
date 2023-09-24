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

    public float currentpropelltime;
    public bool isgoingtoleft;

    public Animator animator;

    public float playermovementspeed;
    public float playermovementspeedbuff = 0;
    public bool movementrestriction;


    public Rigidbody2D yeet;
    public float jumpspeed;
    public float gravitymultiplier;
    Collider2D playercollider;
    public float xMin, xMax;
    float playerymov;
    Collider2D feet;

    // Start is called before the first frame update
    void Start()
    {
        movementrestriction = false;
        animator = GetComponentInChildren<Animator>();
        playercollider = GetComponent<BoxCollider2D>();
        yeet = GetComponent<Rigidbody2D>();
        gravitymultiplier = -0.5f;
        jumpspeed = 6.5f;
        xMin = -3f - playermovementspeedbuff; xMax = 3f + playermovementspeedbuff;
        isonwall = false;
        ispropelling = false;
    }
   

    // Update is called once per frame
    void Update()
    {
      
        xMin = -3f - playermovementspeedbuff; xMax = 3f + playermovementspeedbuff;
        if (boosted == true)
        {
            if (gameObject.transform.localScale.x < 1f) { playermovementspeed = -3f - playermovementspeedbuff; }
            else playermovementspeed = 3f +playermovementspeedbuff;
            yeet.velocity = new Vector2(playermovementspeed + playermovementspeedbuff, 0f);
        }

        if (movementrestriction == false)
        {
        
            if (grounded && boosted == false || isonwall) playermovementspeedbuff = 0;
          


            if (grounded && Input.GetKey(KeyCode.Space)) jump(); else if (!grounded && Input.GetKey(KeyCode.Space) && isonwall && !ispropelling) walljump();





            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && grounded == true) { playermovementspeed = 0; }





            if (Input.GetKey(KeyCode.D) && ispropelling == false && boosted == false) playermovementspeed += 0.02f + playermovementspeedbuff;

            if (Input.GetKey(KeyCode.A) && ispropelling == false && boosted == false) playermovementspeed -= 0.02f + playermovementspeedbuff;



            if (ispropelling == true)
            {


                if (isgoingtoleft == true) { playermovementspeed = -3 - playermovementspeedbuff; }
                else
                {
                    playermovementspeed = 3 + playermovementspeedbuff;

                }

            }



            playermovementspeed = Mathf.Clamp(playermovementspeed, xMin, xMax);

            Vector2 pvelocity = new Vector2(playermovementspeed, yeet.velocity.y);
            yeet.velocity = pvelocity;
            if (playermovementspeed > 0) transform.localScale = new Vector2(3, 3);
            if (playermovementspeed < 0) transform.localScale = new Vector2(-3, 3);


            if (yeet.velocity.y < 0)
            {
                animator.ResetTrigger("Jump");
                yeet.velocity += 0.025f * Vector2.down;
            }

            if (yeet.velocity.y > 0) animator.SetBool("acceleratedown", false); else animator.SetBool("acceleratedown", true);

            if (grounded) animator.SetBool("isgrounded", true); else animator.SetBool("isgrounded", false);
            // animator.SetBool("dontdownaccel", true); else animator.SetBool("downaccel", false);


            if (grounded && playermovementspeed != 0) animator.SetBool("walking", true); else animator.SetBool("walking", false);
        }
        else  yeet.gravityScale = 0;  
        

    }


    

 
    public void jump()
    {
        animator.SetTrigger("Jump");
     
       
        playerymov = jumpspeed;
        Vector2 jumpvelocity = new Vector2(playermovementspeed, playerymov);
    

        yeet.velocity = jumpvelocity;
        


    }
    private IEnumerator Wait()
    {
       
        yield return new WaitForSeconds(0.4f);
       
        ispropelling = false;
    }
    public void walljump()
    {


        if (playermovementspeed > 0) { playermovementspeed = -3f; isgoingtoleft = true;  } else if (playermovementspeed < 0) { playermovementspeed = 3f; isgoingtoleft = false; }


        ispropelling = true;

        playerymov = jumpspeed;
        Vector2 jumpvelocity = new Vector2(playermovementspeed, playerymov);
       

        yeet.velocity = jumpvelocity;

        StartCoroutine(Wait());

     

    }
}
