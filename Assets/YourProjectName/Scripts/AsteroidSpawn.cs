using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject AsteroidPrefab;

    float ySpawn = 1150;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0.0f, 1.2f);        
    }

    void SpawnAsteroid()
    {


        float xSpawn = Random.Range(450,1550);
        Vector3 asteroidVector = new Vector3(xSpawn, ySpawn, 1);

        GameObject asteroid = Instantiate<GameObject>(AsteroidPrefab, asteroidVector, Quaternion.identity);
        Rigidbody2D asteroidRB = asteroid.GetComponent<Rigidbody2D>();
        float horizontalVelocity = Random.Range(-150, 150);
        float verticalVelocity = Random.Range(-130, -100);
        asteroidRB.velocity = new Vector2(horizontalVelocity, verticalVelocity);

    }
}
