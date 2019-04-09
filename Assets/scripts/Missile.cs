using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 10.0f;
    public int lifetime = 10;

    private float secondCounter;
    // Start is called before the first frame update
    void Awake()
    {
        secondCounter = 0;
    }

    // Update is called once per frame
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
