using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StargateSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject StargatePrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnStargate", 15f, 20f);
    }


    void SpawnStargate()
    {
        Instantiate<GameObject>(StargatePrefab, transform.position, Quaternion.identity);
    }

}
