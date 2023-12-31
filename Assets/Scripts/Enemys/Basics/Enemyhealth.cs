using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public int health;
    private damageflash flash;
    public Transform damagenumberAppearTransform;
    public GameObject obj;
    public GameObject[] HitVFX;
    public bool GivesXpOnDeath;
    public int XpAmount;
    public bool canonlybedamagedbyFire;
    public bool canonlybedamagedbyWater;
    public Enemyprojectile projectile;
    public bool isprojectile;
   
    public void dealdamage(int damage, bool firedamage, bool waterdamage)
    {
        if (isprojectile)
        {
            projectile.takedamage();
            return;
        }
        if (canonlybedamagedbyFire == true && firedamage == false) return;
        if (canonlybedamagedbyWater == true && waterdamage == false) return;


        FindObjectOfType<Audiomanager>().Play("Hotsoundenemy");
        flash.Flash();
        health -= damage;
        if (obj != null) 
        { 
        var damagenumber = Instantiate(obj, new Vector3(damagenumberAppearTransform.position.x, damagenumberAppearTransform.position.y + 1, -3), Quaternion.identity);
        damagenumber.GetComponent<Showdamagenumber>().showdamage(damage);
        }
        if(HitVFX[0] != null) { var hitVFX = Instantiate(HitVFX[Random.Range(0,2)], new Vector3(damagenumberAppearTransform.position.x, damagenumberAppearTransform.position.y + 1, -3), Quaternion.identity);  }
       

        if (health <= 0)
        {

            if (GivesXpOnDeath) FindAnyObjectByType<Playerhealth>().GetXp(XpAmount);
            Destroy(gameObject);
        }



    }
    


  
    void Start()
    {
        flash = GetComponent<damageflash>();
        if (isprojectile)
            projectile = GetComponent<Enemyprojectile>();
    }



  
}
