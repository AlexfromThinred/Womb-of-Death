using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cameramovement : MonoBehaviour

{
    public RectTransform _transform;
    public GameObject player;


    void Start()
    {
        
       // Vector3 fdf = new Vector3 player.GetComponent<RectTransform>().localPosition.x + ;
     //  _transform.localPosition = fdf ;
        
    }

 
    void Update()
    {
        _transform.localPosition = player.GetComponent<RectTransform>().localPosition;
        Debug.Log(player.GetComponent<RectTransform>().localPosition.x);
        Debug.Log("yeet" + player.GetComponent<RectTransform>().localPosition);
    }
}
