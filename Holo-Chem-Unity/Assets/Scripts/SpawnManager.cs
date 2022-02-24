using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    Vector3 spawn;
    public GameObject toSpawn;
    public bool spawnActivated = false;
    public Vector3 gizmoLoc;
    public int spawnConstraint = 2;


    [SerializeField] private float sphereOffset = 0.2f;
    [SerializeField] private float sphereSize = 0.4f;

    private float spawnRotationOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawn = gameObject.transform.position;
        spawn = new Vector3(spawn.x, spawn.y + sphereOffset, spawn.z);

        GameObject par = transform.parent.gameObject;
        if(par.name == "BackShelf")
        {
            spawnRotationOffset = 180;
        }

        gizmoLoc = gameObject.transform.position;
        gizmoLoc = new Vector3(gizmoLoc.x, gizmoLoc.y + sphereOffset, gizmoLoc.z);
        SpawnObject(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BoxCollider box = toSpawn.GetComponent<BoxCollider>();

        spawn = gameObject.transform.position;
        spawn = new Vector3(spawn.x, spawn.y + sphereOffset, spawn.z);

        var hitColliders = Physics.OverlapSphere(spawn, sphereSize);

        if(hitColliders.Length == spawnConstraint)
        {
            SpawnObject(spawnRotationOffset);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gizmoLoc, sphereSize);
    }

    void SpawnObject(float extraRotation)
    {
        Quaternion spawnRotation = toSpawn.transform.rotation;
        spawnRotation *= Quaternion.Euler(0, extraRotation, 0);

        if (spawnActivated)
        {
            Object.Instantiate(toSpawn, spawn, spawnRotation, gameObject.transform);
        }
    }

}
