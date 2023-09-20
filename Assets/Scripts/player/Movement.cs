using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool grounded;
    float playermovementspeed;
    float playermovementspeedbuff = 0;
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
        playercollider = GetComponent<BoxCollider2D>();
        yeet = FindObjectOfType<Rigidbody2D>();
        gravitymultiplier = -0.5f;
        jumpspeed = 3.5f;
        xMin = -2f - playermovementspeed; xMax = 2f + playermovementspeed;
    }

  
    // Update is called once per frame
    void Update()
    {

      

        if (grounded && Input.GetKey(KeyCode.Space)) jump();
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && grounded == true) playermovementspeed = 0;
       
        if(Input.GetKey(KeyCode.D)) playermovementspeed += 0.01f + playermovementspeedbuff ;

        if (Input.GetKey(KeyCode.A)) playermovementspeed -= 0.01f + playermovementspeedbuff;
      

        playermovementspeed = Mathf.Clamp(playermovementspeed, xMin, xMax);

        Vector2 pvelocity = new Vector2(playermovementspeed, yeet.velocity.y);
        yeet.velocity = pvelocity;
        if (playermovementspeed > 0) transform.localScale = new Vector2(3, 3);
        if (playermovementspeed < 0) transform.localScale = new Vector2(-3, 3);

        //bug.Log(playerymov);
        //   if (yeet.velocity.y < 0) { playerymov += gravitymultiplier; }

        //  Vector2 pvelocityy = new Vector2(yeet.velocity.x, playerymov);
        //  yeet.velocity = pvelocityy;

        if (yeet.velocity.y < 0)
        {
            yeet.velocity += 0.018f * Vector2.down;
        }




    }



    public void jump()
    {
        Debug.Log("jeet");
        playerymov = jumpspeed;
        Vector2 jumpvelocity = new Vector2(playermovementspeed, playerymov);
    

        yeet.velocity = jumpvelocity;
       


    }
}
