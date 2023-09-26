using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Runestone : MonoBehaviour
{
    GameObject player;
    public Sprite activesprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(this.transform.position, player.transform.position) < 2.5f)
        {
            if (!player.GetComponent<Memory>().knownRunesstones.Contains(this.gameObject))
            {
                // Hinzufügen der Runesstones zu den bekannten Runestones, Umwandlung in die andere Textur (Fancy Sprite + Animation benötigt)
                player.GetComponent<Memory>().knownRunesstones.Add(this.gameObject);
                GetComponent<SpriteRenderer>().sprite = activesprite;
            }
        }
    }
}
