using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public int health;
    private damageflash flash;
    public Transform damagenumberAppearTransform;
    public GameObject obj;
    public GameObject HitVFX;
    public bool GivesXpOnDeath;
    public int XpAmount;
    public bool canonlybedamagedbyFire;
    public bool canonlybedamagedbyWater;

    public void dealdamage(int damage,bool firedamage,bool waterdamage)
    {

        if (canonlybedamagedbyFire == true && firedamage == false) return;
        if (canonlybedamagedbyWater == true && waterdamage == false) return;


        FindObjectOfType<Audiomanager>().Play("Hotsoundenemy");
        flash.Flash();
        health -= damage;

        var damagenumber = Instantiate(obj, new Vector3(damagenumberAppearTransform.position.x, damagenumberAppearTransform.position.y + 1, -3), Quaternion.identity);
        damagenumber.GetComponent<Showdamagenumber>().showdamage(damage);
        if(HitVFX != null) { var hitVFX = Instantiate(HitVFX, new Vector3(damagenumberAppearTransform.position.x, damagenumberAppearTransform.position.y + 1, -3), Quaternion.identity);  }
       

        if (health <= 0)
        {

            if (GivesXpOnDeath) FindAnyObjectByType<Playerhealth>().GetXp(XpAmount);
            Destroy(gameObject);
        }



    }
    


  
    void Start()
    {
        flash = GetComponent<damageflash>();
    }



  
}
