using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    public float fuse = 0.75f;
    public int damage = 40;
    public int explosionDamage = 100;
    public float explosionRadius = 5.0f;
    public GameObject explosionAnimation;

    private bool alive = true;
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
        if(alive)
        {
            secondCounter += Time.deltaTime;
            if (secondCounter > lifetime)
            {
                alive = false;
                Explode();
            }
        }
    }

    async void OnCollisionEnter2D(Collision2D collision)
    {
        if (alive)
        {
            alive = false;
            float fuseTime = fuse * 1000;
            await Task.Delay((int)fuseTime);
            Explode();
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(explosionAnimation);
        explosion.transform.position = transform.position;
    }

    void Explode()
    {

        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(gameObject.transform.position, explosionRadius);
        foreach(Collider2D col in objectsInRange)
        {
            asteroid rock = col.GetComponent<asteroid>();
            Player player = col.GetComponent<Player>();
            if(rock != null)
            {
                rock.ApplyDamage(explosionDamage);
            }
            if(player != null)
            {
                player.ApplyDamage(explosionDamage);
            }
        }
        PlayExplosion();
        Destroy(gameObject);
    }
}
