using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Transform playerTransform;
    public float asteroidSpawnField;
    public float asteroidDespawnField;
    public float asteroidSpawnDelay;
    public int maxAsteroidCount;
    public GameObject[] asteroidPrefabs;
    private List<asteroid> spawnedAsteroids;

    void Awake()
    {
        spawnedAsteroids = new List<asteroid>();
    }

    // Update is called once per frame
    void Update()
    {
        for(var i = 0; i < spawnedAsteroids.Count; ++i)
        {
            var currentAsteroid = spawnedAsteroids[i];
            if((currentAsteroid.transform.position - playerTransform.position).magnitude >= asteroidDespawnField)
            {
                GameObject.Destroy(currentAsteroid.gameObject);
                spawnedAsteroids.RemoveAt(i);
                i = i - 1;
            }
        }
        while(spawnedAsteroids.Count < maxAsteroidCount)
        {
            SpawnAsteroid();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, asteroidSpawnField);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, asteroidDespawnField);
        Gizmos.color = Color.white;
    }

    void SpawnAsteroid()
    {
        float angle = Mathf.Lerp(-Mathf.PI, Mathf.PI, Random.value); //Choose a random value between -3.14 and 3.14. Random angle on a circle
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        Vector2 spawnPosition = (Vector2)playerTransform.position + direction * asteroidSpawnField;
        GameObject asteroidPrefab = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
        var asteroid = GameObject.Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        spawnedAsteroids.Add(asteroid.GetComponent<asteroid>());
    }
}
