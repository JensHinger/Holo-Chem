using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNewParent : MonoBehaviour
{

    public void SetParent()
    {
        transform.parent = null;

        ShowNameTag nametagScript = GetComponent<ShowNameTag>();
        
        if(nametagScript != null) {
            nametagScript.HideSign();
            Destroy(nametagScript);
        }
    }
}
