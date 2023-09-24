using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afterimagepool : MonoBehaviour
{
    [SerializeField]
    private GameObject afterimageprefab;


    private Queue<GameObject> availableObj = new Queue<GameObject>();
        public static Afterimagepool instance { get; private set; }

    private void Awake()
    {
        instance = this;
        growpool();
    }
    private void growpool()
    {
        for(int i = 0; i< 10; i++)
        {
            var instacetoadd = Instantiate(afterimageprefab);
            instacetoadd.transform.SetParent(transform);
            addtopool(instacetoadd);
        }
    }

    public void addtopool(GameObject instace)
    {
        instace.SetActive(false);
        availableObj.Enqueue(instace);
    }

    public GameObject pullfromPool()
    {
        if(availableObj.Count == 0)
        {
            growpool();
        }
        var instance = availableObj.Dequeue();
        instance.SetActive(true);
        return instance;
    }
}
