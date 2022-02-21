using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    [Header("StartScale")]
    public float scaleModifier = 0.5f;

    [Header("Size up")]
    public float targetScale = 1.05f;
    public float timeToGrow = 0.5f;

    [Header("Size down")]
    public float normalScale = 0.95f;
    public float timeToShrink = 0.5f;

    private Vector3 startScale;

    void Start()
    {
        // Get base scale of gameObject
        startScale = transform.localScale;

        // Start Coroutine which makes Object Larger to size of targetScale
        StartCoroutine(LerpLarger(targetScale, timeToGrow));
    }
     
    IEnumerator LerpLarger(float endValue, float duration)
    {
        float time = 0;

        // Start the object on a smaller size so scaleModifier < 1
        float startValue = scaleModifier;

        while (time < duration)
        {
            // use Lerp to slowly go from startValue to endValue
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            // Modify gameObject scale by the scalmodifier
            transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }

        // Set the localScale to the targetScale
        transform.localScale = startScale * targetScale;
        scaleModifier = targetScale;

        // Call a Second Coroutine which makes the object smaller
        StartCoroutine(LerpSmaller(normalScale, timeToShrink, startScale * targetScale));
    }

    IEnumerator LerpSmaller(float endValue, float duration, Vector3 endScale)
    {

        float time = 0;
        float startValue = 1;

        Vector3 newScale = Vector3.zero;

        // Get ScaleDifference for each axis
        float scaleDiffX = (endScale.x - startScale.x) / startScale.x;
        float scaleDiffY = (endScale.y - startScale.y) / startScale.y;
        float scaleDiffZ = (endScale.z - startScale.z) / startScale.z;

        while (time < duration && transform.localScale.x > startScale.x)
        {    
            // Calculate the scaleModifier for each axis
            float scaleModifierX = Mathf.Lerp(startValue, 1 - scaleDiffX, time / duration);
            float scaleModifierY = Mathf.Lerp(startValue, 1 - scaleDiffY, time / duration);
            float scaleModifierZ = Mathf.Lerp(startValue, 1 - scaleDiffZ, time / duration);
            
            // Set the localScale to the scale * scaleModifier
            newScale = new Vector3(endScale.x * scaleModifierX, endScale.y * scaleModifierY, endScale.z * scaleModifierZ);
            transform.localScale = newScale;

            time += Time.deltaTime;
            yield return null;
        }

        // Set the localScale to the baseScale
        transform.localScale = startScale;
        scaleModifier = endValue;
    }
}
