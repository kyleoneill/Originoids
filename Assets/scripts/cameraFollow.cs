using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float trackingSpeed = 0.15f;
    public float cameraHeight = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 cameraPosition = Vector3.Lerp(transform.position, playerTransform.position, trackingSpeed);
        cameraPosition.z = cameraHeight;
        transform.position = cameraPosition;
    }
}
