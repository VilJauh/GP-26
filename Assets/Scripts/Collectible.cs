using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;

    public float amplitude = 2;
    public float speed = 1.5f;
    Vector3 initPos;

    private void Awake()
    {
        total++;
    }
    private void Start()
    {
        initPos = transform.position;
    }
    private void Update()
    {
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * speed) * amplitude + initPos.y, initPos.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
