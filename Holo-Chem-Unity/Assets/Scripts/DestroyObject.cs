using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
     public void DestroySelf()
     {
        Destroy(gameObject);
     }
}
