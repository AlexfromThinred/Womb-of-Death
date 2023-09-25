using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArrowMovement : MonoBehaviour
{
  
    public WeaponData weaponData;
    public new SpriteRenderer renderer;
    Rigidbody2D rb;
    Vector3 oldPosition;
    // Start is called before the first frame update
    void Start()
    {
        weaponData = GameObject.FindGameObjectWithTag("player").GetComponent<Memory>().currentWeaponData;
        renderer = GetComponent<SpriteRenderer>();
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = true;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * 6f;
    }

    // Update is called once per frame
    void Update()
    {

        
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Enemyhealth>() == null) { Debug.Log("no enemy"); return; }
        Debug.Log("Hallo");
        other.GetComponent<Enemyhealth>().dealdamage((weaponData.damage));
        Destroy(gameObject);
        
    }
}
