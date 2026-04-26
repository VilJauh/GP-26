using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform cartransform;
    [SerializeField]
    private Transform camTransform;

    [SerializeField]
    private float smoothingTime = 5f;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        transform.LookAt(cartransform);
        transform.position = Vector3.SmoothDamp(transform.position, camTransform.position, ref velocity, smoothingTime * Time.deltaTime);
    }
}
