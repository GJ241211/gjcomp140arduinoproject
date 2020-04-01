using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject AsteroidPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0.0f, 2.0f);
        
    }

    void SpawnAsteroid()
    {
        GameObject asteroid = Instantiate<GameObject>(AsteroidPrefab, transform.position, Quaternion.identity);
        Rigidbody2D asteroidRB = asteroid.GetComponent<Rigidbody2D>();
        float horizontalVelocity = Random.Range(-100, 100);
        float verticalVelocity = Random.Range(-130, -100);
        asteroidRB.velocity = new Vector2(horizontalVelocity, verticalVelocity);

    }
}
