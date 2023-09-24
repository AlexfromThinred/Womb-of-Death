using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cameramovement : MonoBehaviour

{
    public RectTransform _transform;
    public GameObject player;


    public void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    void Start()
    {
        
       Vector3 fdf = new Vector3 (player.GetComponent<RectTransform>().localPosition.x, player.GetComponent<RectTransform>().localPosition.y + 0, -10) ;
     _transform.localPosition = fdf;

    }


    void Update()
    {
        Vector3 fdf = new Vector3(player.GetComponent<RectTransform>().localPosition.x, player.GetComponent<RectTransform>().localPosition.y + 0, -10);
        _transform.localPosition = fdf;


        //   +
    }
}
