using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public int health;
    private damageflash flash;

    public GameObject obj;

    public bool canonlybedamagedbyFire;
    public bool canonlybedamagedbyWater;

    public void dealdamage(int damage,bool firedamage,bool waterdamage)
    {

        if (canonlybedamagedbyFire == true && firedamage == false) return;
        if (canonlybedamagedbyWater == true && waterdamage == false) return;

        flash.Flash();
        health -= damage;

        var damagenumber = Instantiate(obj, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 1, -3), Quaternion.identity);
        damagenumber.GetComponent<Showdamagenumber>().showdamage(damage);

        if (health <= 0) Destroy(gameObject);



    }
    


  
    void Start()
    {
        flash = GetComponent<damageflash>();
    }



  
}
