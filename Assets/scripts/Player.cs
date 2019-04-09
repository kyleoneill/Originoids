using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    Animator _animator;
    public float movementSpeed = 5.0f;
    public float maxSpeed = 15.0f;
    public int maxHealth = 100;
    public float torque = 0.25f;
    public float maxRotation = 360.0f;
    public int deathWaitTime = 5000;
    private int currentHealth;
    public float invulnerabilityTime;
    public GameObject gameOverPanel;
    public GameObject missile;
    public int missileFireLength = 1;

    private float invulnerabilityTimeRemaining;
    private bool isAlive;
    // Awake is called right after construction
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        isAlive = true;
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                _rigidbody.AddForce(Vector2.right * movementSpeed);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                _rigidbody.AddForce(Vector2.left * movementSpeed);
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                _rigidbody.AddForce(Vector2.up * movementSpeed);
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                _rigidbody.AddForce(Vector2.down * movementSpeed);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                _rigidbody.AddTorque(torque);
            }
            if (Input.GetKey(KeyCode.E))
            {
                _rigidbody.AddTorque(-torque);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Fire();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                KillPlayer();
            }

            invulnerabilityTimeRemaining -= Time.deltaTime;
            _animator.SetBool("invulnerable", invulnerabilityTimeRemaining > 0);
        }
    }
    void FixedUpdate()
    {
        float speed = _rigidbody.velocity.magnitude;
        Vector2 newVelocity = _rigidbody.velocity.normalized * Mathf.Min(maxSpeed, speed);
        _rigidbody.velocity = newVelocity;

        float angularVelocity = Mathf.Abs(_rigidbody.angularVelocity);
        float cappedAngularVelocity = Mathf.Sign(_rigidbody.angularVelocity) * Mathf.Min(maxRotation, angularVelocity);
        _rigidbody.angularVelocity = cappedAngularVelocity;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var asteroid = col.gameObject.GetComponent<asteroid>();
        if(asteroid != null){
            ApplyDamage(asteroid.damage);
        }
    }

    public float GetHealth()
    {
        return((float)currentHealth/(float)maxHealth);
    }

    public void ApplyDamage(int damage)
    {
        if(invulnerabilityTimeRemaining > 0){
            return;
        }
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            KillPlayer();
        }
        else
        {
            invulnerabilityTimeRemaining = invulnerabilityTime;
        }
    }

    void Fire()
    {
        Vector3 missileOffset = transform.position + transform.up * missileFireLength;
        var newMissile = GameObject.Instantiate(missile, missileOffset, transform.rotation);
    }

    async void KillPlayer()
    {
        isAlive = false;
        gameOverPanel.SetActive(true);
        await Task.Delay(deathWaitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //TODO: Add top score leaderboard
        //TODO: Explosion Animation
        //TODO: Explosion Sound
    }

    public bool getLifeStatus()
    {
        return isAlive;
    }

}
