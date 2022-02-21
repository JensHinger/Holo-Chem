using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNewParent : MonoBehaviour
{

    public void SetParentNull()
    {
        Vector3 originalPosition = transform.position;
        Quaternion originalRotation = transform.rotation;

        transform.SetParent(null, false);

        transform.position = originalPosition;
        transform.rotation = originalRotation;

        ShowNameTag nametagScript = GetComponent<ShowNameTag>();
        
        if(nametagScript != null) {
            nametagScript.HideSign();
            Destroy(nametagScript);
        }
    }
}
