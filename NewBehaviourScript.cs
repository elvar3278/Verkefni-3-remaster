using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hlutursnu : MonoBehaviour
{
    // Speed of rotation along each axis
    public float xSpeed = 0f;
    public float ySpeed = 0f;
    public float zSpeed = 0f;

    // Factor by which the object will scale
    public float scaleFactor = 1.2f;
    // Duration for each scaling operation
    public float duration = 1.0f;

    private void Start()
    {
        // Start the scaling loop when the object is created
        StartCoroutine(ScaleLoop());
    }

    void Update()
    {
        // Rotate the object based on provided speed values
        transform.Rotate(new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime);
    }

    private IEnumerator ScaleLoop()
    {
        // Infinite loop to continuously scale the object
        while (true)
        {
            // Scale up
            yield return ScaleCoroutine(Vector3.one * scaleFactor, duration);
            // Scale down
            yield return ScaleCoroutine(Vector3.one / scaleFactor, duration);
        }
    }

    private IEnumerator ScaleCoroutine(Vector3 targetScale, float duration)
    {
        // Store the initial scale of the object
        Vector3 startScale = transform.localScale;
        // Record the starting time of scaling operation
        float startTime = Time.time;
        // Calculate the time when scaling should end
        float endTime = startTime + duration;

        // Loop until the duration is over
        while (Time.time < endTime)
        {
            // Calculate the progress of scaling based on time
            float progress = (Time.time - startTime) / duration;
            // Interpolate between the initial scale and target scale
            transform.localScale = Vector3.Lerp(startScale, targetScale, progress);
            // Wait for the next frame
            yield return null;
        }

        // Ensure that the scale is precisely set to the target scale at the end
        transform.localScale = targetScale;
    }
}
