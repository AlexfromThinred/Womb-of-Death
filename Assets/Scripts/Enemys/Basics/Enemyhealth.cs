using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public int health;

    public GameObject obj;

  
    public void dealdamage(int damage)
    {

        health -= damage;

        var damagenumber = Instantiate(obj, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 1, -3), Quaternion.identity);
        damagenumber.GetComponent<Showdamagenumber>().showdamage(damage);

        if (health <= 0) Destroy(gameObject);



    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
