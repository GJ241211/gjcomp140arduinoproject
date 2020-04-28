using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StargateSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject StargatePrefab;

    // regularly spawn gates at an interval.
    void Start()
    {
        InvokeRepeating("SpawnStargate", 15f, 20f);
    }


    void SpawnStargate()
    {
        Instantiate<GameObject>(StargatePrefab, transform.position, Quaternion.identity);
    }

}
