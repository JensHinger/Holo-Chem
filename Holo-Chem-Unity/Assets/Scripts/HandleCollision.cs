using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollision : MonoBehaviour
{
    public delegate void OnCollision(GameObject first, GameObject second);
    public static event OnCollision OnMaterialCollision;


    private void OnCollisionEnter(Collision collision)
    {
        // Check both GameObjects for the "Material" tag
        if (gameObject.CompareTag("Material") && collision.gameObject.CompareTag("Material"))
        {
            // Get HandleCollision Script from other gameObject
            HandleCollision other_script = collision.collider.GetComponent<HandleCollision>();

            // Only trigger the event if the current InstanceID is smaller than the other InstanceID
            if(other_script != null && other_script.GetInstanceID() > GetInstanceID())
            {
                // Trigger the OnMaterialCollision Event
                OnMaterialCollision?.Invoke(gameObject, collision.gameObject);
              }
        }
    }
}
