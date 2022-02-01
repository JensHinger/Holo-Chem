using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject toSpawn;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BoxCollider box = toSpawn.GetComponent<BoxCollider>();

        var spawn = gameObject.transform.position;
        var hitColliders = Physics.OverlapSphere(spawn, box.size.x /4); 

        Debug.Log(hitColliders.Length + " size: " + box.size.x);

        if(hitColliders.Length == 2)
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
         Object.Instantiate(toSpawn, gameObject.transform.position, toSpawn.transform.rotation);
    }

}
