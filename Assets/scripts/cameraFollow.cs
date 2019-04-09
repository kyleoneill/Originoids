using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float trackingSpeed = 0.15f;
    public float cameraHeight = -10.0f;
    public float minFov = 7f;
    public float maxFov = 12f;
    public float sensativity = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        float cameraSize = Camera.main.orthographicSize;
        cameraSize -= Input.GetAxis("Mouse ScrollWheel") * sensativity;
        cameraSize = Mathf.Clamp(cameraSize, minFov, maxFov);
        Camera.main.orthographicSize = cameraSize;
    }

    void FixedUpdate()
    {
        Vector3 cameraPosition = Vector3.Lerp(transform.position, playerTransform.position, trackingSpeed);
        cameraPosition.z = cameraHeight;
        transform.position = cameraPosition;
    }
}
