using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with" + collision.gameObject.tag);
        if (gameObject.CompareTag("Material") && collision.gameObject.CompareTag("Material"))
        {
            // Check for combinations
            // Destroy both elements
        }
    }
}
