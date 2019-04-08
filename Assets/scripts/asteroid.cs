using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public float minSpeed = 0.0f;
    public float maxSpeed = 5.0f;
    public float minRotation = -360.0f;
    public float maxRotation = 360.0f;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        float angle = Mathf.Lerp(-Mathf.PI, Mathf.PI, Random.value); //Choose a random value between -3.14 and 3.14. Random angle on a circle
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float speed = Mathf.Lerp(minSpeed, maxSpeed, Random.value);
        _rigidbody.velocity = direction * speed;

        _rigidbody.angularVelocity = Mathf.Lerp(minRotation, maxRotation, Random.value);
    }

    void Update()
    {
        
    }
}
