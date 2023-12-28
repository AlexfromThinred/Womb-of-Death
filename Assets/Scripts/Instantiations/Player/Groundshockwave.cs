using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundshockwave : MonoBehaviour
{

    public Transform left;
    public Transform right;
    public bool leftdraw;
    public Transform GarenE;

    public void inst()
    {
        if (leftdraw)
            gameObject.transform.localScale = new Vector2( -gameObject.transform.localScale.x, gameObject.transform.localScale.y);
    }
    public void dealdamageleft()
    {
        Collider2D[] hitEnemiesleft = Physics2D.OverlapBoxAll(left.position, new Vector2(1.3f, 0.5f), 0);
        foreach (Collider2D enemy in hitEnemiesleft)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)

                enemy.GetComponent<Enemyhealth>().dealdamage(1, false, false);

        }

        Collider2D[] hitEnemiesright = Physics2D.OverlapBoxAll(right.position, new Vector2(1.3f, 0.5f), 0);
        foreach (Collider2D enemy in hitEnemiesright)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)

                enemy.GetComponent<Enemyhealth>().dealdamage(1, false, false);

        }
    }

    public void dealDamageGarenE()
    {
       
        Collider2D[] hitEnemiesleft = Physics2D.OverlapCircleAll(GarenE.position, 1f);
        foreach (Collider2D enemy in hitEnemiesleft)
        {
            if (enemy.GetComponent<Enemyhealth>() != null)

                enemy.GetComponent<Enemyhealth>().dealdamage(5, false, false);

        }
    }

        public void destroygameobj()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
      
        Gizmos.DrawSphere(GarenE.position, 1);
        Gizmos.DrawCube(left.position, new Vector3(1.3f, 0.5f, 0));

    }

    public void SwordBiteAudio()
    {
        FindObjectOfType<Audiomanager>().Play("SwordBiteAudio");
    }


}
