using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float returnTime;
    public float followSpeed;
    public float length;
    public Transform target;

    private Vector3 defaultPosition;

    private void Start()
    {
        defaultPosition = transform.position;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = target.position + (targetToCameraDirection * length);

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    public void FollowTarget(Transform targetTransform, float targetLength)
    {
        StopAllCoroutines();
        target = targetTransform;
        length = targetLength;
    }

    public void GoBackToDefault()
    {
        StopAllCoroutines();
        StartCoroutine(MovePosition(defaultPosition, returnTime));
    }

    private IEnumerator MovePosition(Vector3 target, float time)
    {
        float timer = 0;
        Vector3 start = transform.position;

        while (timer < time)
        {
            // Move the camera gradually
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f, 1.0f, timer / time));

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = target;
    }
}
