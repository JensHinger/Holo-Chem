using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject toSpawn;
    public bool spawnActivated = false;
    public Vector3 gizmoLoc;

    [SerializeField] private float sphereOffset = 0.2f;
    [SerializeField] private float sphereSize = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        // gizmoLoc = gameObject.transform.position;
        // gizmoLoc = new Vector3(gizmoLoc.x, gizmoLoc.y + sphereOffset, gizmoLoc.z);
        SpawnObject();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BoxCollider box = toSpawn.GetComponent<BoxCollider>();

        Vector3 spawn = gameObject.transform.position;
        spawn = new Vector3(spawn.x, spawn.y+sphereOffset, spawn.z);

        var hitColliders = Physics.OverlapSphere(spawn, sphereSize);

        if(hitColliders.Length == 2)
        {
            SpawnObject();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gizmoLoc, sphereSize);
    }

    void SpawnObject()
    {
        if (spawnActivated)
        {
            Object.Instantiate(toSpawn, gameObject.transform.position, toSpawn.transform.rotation, gameObject.transform);
        }
    }

}
