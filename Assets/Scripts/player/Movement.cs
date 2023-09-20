using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    float playermovementspeed;
    float playermovementspeedbuff;
    public Rigidbody2D yeet;
 

    // Start is called before the first frame update
    void Start()
    {
        yeet = FindObjectOfType<Rigidbody2D>();
        playermovementspeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playermovementspeed = 0;
        if(Input.GetKey(KeyCode.D)) playermovementspeed += 1 + playermovementspeedbuff;

        if (Input.GetKey(KeyCode.A)) playermovementspeed -= 1 + playermovementspeedbuff;

        Vector2 pvelocity = new Vector2(playermovementspeed, yeet.velocity.y);
        yeet.velocity = pvelocity;
        if (playermovementspeed > 0) transform.localScale = new Vector2(1, 1);
        if (playermovementspeed < 0) transform.localScale = new Vector2(-1, 1);
    }
}
