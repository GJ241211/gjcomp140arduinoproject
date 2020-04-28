using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject AsteroidPrefab;

    float ySpawn = 1150; // constant value to ensure asteroids spawn out of veiw (above)

    // spawns a new asteroid at regular intervals
    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0.0f, 1.2f);        
    }

    void SpawnAsteroid()
    {
        //picks a spawning point randomley along x axis within peraameters
        float xSpawn = Random.Range(450,1550);
        Vector3 asteroidVector = new Vector3(xSpawn, ySpawn, 1);

        //spawns an instance of the asteroid prefab and creates reference to its rigidbody for movement
        GameObject asteroid = Instantiate<GameObject>(AsteroidPrefab, asteroidVector, Quaternion.identity);
        Rigidbody2D asteroidRB = asteroid.GetComponent<Rigidbody2D>();
        
        // gives the instance random x,y speeds within a range and sets there velocity
        float horizontalVelocity = Random.Range(-150, 150);
        float verticalVelocity = Random.Range(-130, -100);
        asteroidRB.velocity = new Vector2(horizontalVelocity, verticalVelocity);

    }
}
