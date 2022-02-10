using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShelves : MonoBehaviour
{
    public float timeToRotate = 2f;
    public GameObject toRotate;

    private bool rotate = false;

    private float blockTimer;
    private bool blockRotate = false;

    IEnumerator Rotate()
    {
        Quaternion fromAngle = toRotate.transform.rotation;
        Quaternion toAngle = Quaternion.Euler(toRotate.transform.eulerAngles + Vector3.up * 180);

        for(var t = 0f; t < 1; t+= Time.deltaTime / timeToRotate)
        {
            toRotate.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }

    }

    public void setRotate()
    {
        rotate = true;
    }

    void Update()
    {
        if (rotate && !blockRotate)
        {
            rotate = false;
            blockRotate = true;
            blockTimer = timeToRotate + 0.5f;
            StartCoroutine(Rotate());
        }

        if (blockRotate)
        {
            blockTimer -= Time.deltaTime;
        }

        if(blockTimer <= 0f)
        {
            blockRotate = false;
        }

    }
}
