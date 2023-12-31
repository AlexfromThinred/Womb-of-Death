using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStuff : MonoBehaviour
{
    Moveenemy position;
    public float force;
    public void Start()
    {
        position = GetComponent<Moveenemy>();
    }

    public void Throwprojectile(GameObject projectileobj)
    {
        //  position.playertransform

        var projectile = Instantiate(projectileobj, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0),
                  Quaternion.Euler(0f, 0f, (Mathf.Atan2(position.playertransform.localPosition.y - Camera.main.WorldToScreenPoint(gameObject.transform.localPosition).y, position.playertransform.localPosition.x - Camera.main.WorldToScreenPoint(gameObject.transform.localPosition).x) * Mathf.Rad2Deg)));
        Debug.Log(position.playertransform.localPosition.y);
        Vector3 direction = position.playertransform.localPosition - gameObject.transform.localPosition;

        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x,direction.y).normalized * force;


        projectile.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(projectile.GetComponent<Rigidbody2D>().velocity.y, projectile.GetComponent<Rigidbody2D>().velocity.x) * Mathf.Rad2Deg, Vector3.forward);
    }
}
