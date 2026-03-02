using UnityEngine;

public class FinderRaycast : MonoBehaviour
{
    [SerializeField] private float rayDistance = 2f;
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, rayDistance))
        {
            FindAreaMessage(hit);
        }
    }
    private void FindAreaMessage(RaycastHit hit) 
    {
        if (hit.collider.gameObject.name == "TriggerArea")
        {
            Debug.Log("Found the area");
        }
    }
}
