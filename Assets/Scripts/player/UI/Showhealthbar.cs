using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Showhealthbar : MonoBehaviour
{
    public Slider slider;
    public GameObject[] healthorbs;
    public Playerhealth health;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.Healplayer(3);
        }
    }
    public void Changehealth(int i)
    {

      
        slider.value = health.currenthealthOfAffectedHealthbar;
        if(slider.value <= 0)
        {
            healthorbs[i].GetComponent<Image>().color = new Color32(108, 70, 0, 255);
        }
    }

    public void HealaHealthOrb(int i)
    {
        healthorbs[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void Givefulllife()
    {
        slider.value = health.playerhealthProBalken;
        for (int i = 0; i < 6; i++)
        {

            healthorbs[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        }
    }
    public void Setupthehealthbars(int setting)
    {
      
        health = FindAnyObjectByType<Playerhealth>();
        slider.maxValue = health.playerhealthProBalken;
        for (int i = 0; i < 6; i++)
        {
            if (setting <= i)
            {
                healthorbs[i].SetActive(false);

            }
            else
            {
                healthorbs[i].SetActive(true);   //slider[i].gameObject.GetComponent<Image>().color = new Color(154, 154, 154, 255);
             
               
            }


        }

        Givefulllife();

    }
}
