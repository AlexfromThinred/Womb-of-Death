using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spelleffects : MonoBehaviour
{
    public Transform icebreathhitbox;
    public void freeze()
    {
     

            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(icebreathhitbox.position, new Vector2(2.5f, 1.2f), 0);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.GetComponent<Moveenemy>() != null)
                {

                enemy.GetComponent<Moveenemy>().gettingfotzen();
                 
                }
            }
        
    }
}
