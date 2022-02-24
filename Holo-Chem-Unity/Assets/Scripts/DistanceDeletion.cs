using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDeletion : MonoBehaviour
{
    private float deletionDistance = 10f;
    private Vector3 startLocation;

    private void Start()
    {
        startLocation = gameObject.transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(startLocation, gameObject.transform.position) > deletionDistance)
        {
            Destroy(gameObject);
        }
    }
}
