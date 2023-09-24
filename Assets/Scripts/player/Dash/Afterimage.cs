using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afterimage : MonoBehaviour
{
    [SerializeField]
    private float activeTime = 0.4f;
    private float timeActivated;
    private float alpha;
    [SerializeField]
    private float aplphaset = 0.8f;
    private float alphaMultipliuer = 0.9668f;

    private Transform player;
    private SpriteRenderer playerSR;
    private SpriteRenderer SR;

    private Color color;

    private void OnEnable()
    {
        GameObject playerobject = GameObject.FindGameObjectWithTag("player");




        SR = GetComponent<SpriteRenderer>();

        if (playerobject.transform.localScale.x < 1f) SR.flipX = true; else SR.flipX = false;

      
       player = playerobject.transform;
        playerSR = player.GetComponentInChildren<SpriteRenderer>();

        alpha = aplphaset;
        SR.sprite = playerSR.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActivated = Time.time;
    }

    private void Update()
    {
        alpha *= alphaMultipliuer;
        color = new Color(1f, 1f, 1f, alpha);
        SR.color = color;

        if(Time.time >= (timeActivated + activeTime))
        {
            Afterimagepool.instance.addtopool(gameObject);
        }
    }
}
