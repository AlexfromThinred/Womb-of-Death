using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Showdamagenumber : MonoBehaviour
{

    public Rigidbody2D rigidBody;

    public TextMesh text;


    public void showdamage(int damagedone)
    {
        text.text = damagedone.ToString();
    }

    public void Start()
    {
        StartCoroutine("living");

        rigidBody.velocity = new Vector2(1f, 3f);

        
    }


    public IEnumerator living()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }



}
