using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Missile Ideas
 * -Missile hits an object and deals small amount of damage.
 * -After making contact, a timer begins
 * -After the timer runs out, missile explodes
 * -Maybe make it a percent chance per second to explode
 */


public class Missile : MonoBehaviour
{
    public float speed = 200.0f;
    public int lifetime = 10;

    private Rigidbody2D _rigidbody;

    private float secondCounter;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        secondCounter = 0;
    }

    private void Start()
    {
        _rigidbody.velocity = transform.up * speed;
    }

    void Update()
    {
        secondCounter += Time.deltaTime;
        if(secondCounter > lifetime)
        {
            Explode();
        }
    }

    void Explode()
    {
        Destroy(gameObject);
    }
}
