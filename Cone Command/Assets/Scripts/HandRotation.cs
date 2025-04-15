using UnityEngine;
using System.Collections;

public class HandRotation : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis = Vector3.right;
    [SerializeField] private float minAngleOffset = -102.0f;
    [SerializeField] private float maxAngleOffset = -9.5f;
    [SerializeField] private float rotationSpeed = 30000f;
    //[SerializeField] private float delayBeforeReturn = 0.2f;

    private Quaternion initialRotation;
    private bool isRotating = false;
    void Start()
    {
        initialRotation = transform.localRotation;
    }

    public void PerformRotation()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateBackAndForth());
        }
        else
        {
            Debug.LogWarning("Rotation already in progress.");
        }
    }

    private IEnumerator RotateBackAndForth()
    {
        isRotating = true;

        Quaternion targetRotationBack = initialRotation * Quaternion.AngleAxis(minAngleOffset, rotationAxis);
        float timeElapsed = 0f;
        float durationBack = Mathf.Abs(minAngleOffset) / rotationSpeed;

        while (timeElapsed < durationBack)
        {
            transform.localRotation = Quaternion.Slerp(initialRotation, targetRotationBack, timeElapsed / durationBack);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.localRotation = targetRotationBack;

        Quaternion targetRotationForward = initialRotation * Quaternion.AngleAxis(maxAngleOffset, rotationAxis);
        timeElapsed = 0f;
        float durationForward = Mathf.Abs(maxAngleOffset - minAngleOffset) / rotationSpeed;

        while (timeElapsed < durationForward)
        {
            transform.localRotation = Quaternion.Slerp(targetRotationBack, targetRotationForward, timeElapsed / durationForward);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.localRotation = targetRotationForward;

        timeElapsed = 0f;
        float durationReturn = Mathf.Abs(maxAngleOffset) / rotationSpeed;

        while (timeElapsed < durationReturn)
        {
            transform.localRotation = Quaternion.Slerp(targetRotationForward, initialRotation, timeElapsed / durationReturn);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.localRotation = initialRotation;

        isRotating = false;
    }
}
