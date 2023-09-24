using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exitfromgam : MonoBehaviour
{

    public Canvas canvas;
    public void Awake()
    {

        canvas = GetComponent<Canvas>();
      
        canvas.enabled = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canvas.enabled == true)
        {
            canvas.enabled = false;
            Time.timeScale = 1;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && canvas.enabled == false)
        {
            Time.timeScale = 0;
            canvas.enabled = true;

        }
    }
}
