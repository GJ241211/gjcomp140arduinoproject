using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZones : MonoBehaviour
{
    // destroys bullets, asteroids and stargates as they hit colliders connected to this script
    // so game objects not needed get cleaned up.

    void OnTriggerEnter2D(Collider2D col)
    {        
            Destroy(col.gameObject);
    }
}
