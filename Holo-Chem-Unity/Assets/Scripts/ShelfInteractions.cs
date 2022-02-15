using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfInteractions : MonoBehaviour
{
    private float multiplierX = 2.2f;
    private float multiplierY = 2.2f;
    private float multiplierZ = 1.4f;
    private float offsetY = 1.5f;

    private Vector3 boxSize;
    private Vector3 boxPos;


    // Start is called before the first frame update
    void Start()
    {
        boxSize = Vector3.one;
        boxSize.x += multiplierX;
        boxSize.y += multiplierY;
        boxSize.z += multiplierZ;

        boxPos = transform.position;
        boxPos.y += offsetY;
    }

    public bool CheckInShelf(GameObject toCheck)
    {
        Collider[] colliding = Physics.OverlapBox(transform.position, boxSize / 2);

        foreach(Collider col in colliding) 
        {
            if(col.gameObject == toCheck)
            {
                return false;
            }
        }

        return true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxPos, boxSize);
    }
}
