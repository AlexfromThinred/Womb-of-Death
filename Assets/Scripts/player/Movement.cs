using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool grounded;
    float playermovementspeed;
    float playermovementspeedbuff;
    public Rigidbody2D yeet;
    public float jumpspeed;
    Collider2D playercollider;
    private float xMin, xMax;
    

    // Start is called before the first frame update
    void Start()
    {
        playercollider = GetComponent<BoxCollider2D>();
        yeet = FindObjectOfType<Rigidbody2D>();
      
        jumpspeed = 3.5f;
        xMin = -2f - playermovementspeed; xMax = 2f + playermovementspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (yeet.velocity.y == 0) grounded = true; else grounded = false;


        if (grounded && Input.GetKey(KeyCode.Space)) jump();
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && grounded == true) playermovementspeed = 0;
       
        if(Input.GetKey(KeyCode.D)) playermovementspeed += 0.02f + playermovementspeedbuff ;

        if (Input.GetKey(KeyCode.A)) playermovementspeed -= 0.02f + playermovementspeedbuff;
        Debug.Log(playermovementspeed);

        playermovementspeed = Mathf.Clamp(playermovementspeed, xMin, xMax);

        Vector2 pvelocity = new Vector2(playermovementspeed, yeet.velocity.y);
        yeet.velocity = pvelocity;
        if (playermovementspeed > 0) transform.localScale = new Vector2(3, 3);
        if (playermovementspeed < 0) transform.localScale = new Vector2(-3, 3);




       
    }



    public void jump()
    {
        Debug.Log("jeet");
        Vector2 jumpvelocity = new Vector2(0f, jumpspeed);

        yeet.velocity += jumpvelocity;
       


    }
}
