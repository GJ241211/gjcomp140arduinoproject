using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    GameObject BulletPrefab;
    [SerializeField]
    GameObject BulletSpawnpoint;
    [SerializeField]
    int shots = 5;

    // Would this be part of player controller?
    void Update()
    {
        if (shots > 0)
        {
            if (Input.GetKeyDown("space"))
            {
                ShootBullet();
                shots --;
            }
        }
    }

    private void Start()
    {
        InvokeRepeating("RegenerateBullet", 0.0f, 3f);
    }

    void RegenerateBullet()
    {
        if (shots < 5)
        {
            shots++;
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate<GameObject>(BulletPrefab, BulletSpawnpoint.transform.position, Quaternion.identity);
        
    }
}
