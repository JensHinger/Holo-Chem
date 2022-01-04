using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidertest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale += new Vector3(1, 1, 1);
    }
}
