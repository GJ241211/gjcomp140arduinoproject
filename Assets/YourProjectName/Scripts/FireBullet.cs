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
    [SerializeField]
    GameManager gameManager;

    bool controllerBtn = false;
    bool fireEnabled = true;

    // Would this be part of player controller?
    void Update()
    {

        if (shots > 0 && fireEnabled == true)
        {
            if (Input.GetKeyDown("space") || controllerBtn == true)
            {
                //Turn of the light before moving the shot counter down!
                gameManager.ToggleLight(shots);
                ShootBullet();
                shots--;
                Debug.Log("current shot" + shots);
                controllerBtn = false;

                fireEnabled = false;
                StartCoroutine(ExampleCoroutine());
                
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
            gameManager.ToggleLight(shots);
        }
    }

    public void ShootBullet()
    {
        GameObject bullet = Instantiate<GameObject>(BulletPrefab, BulletSpawnpoint.transform.position, Quaternion.identity);
        
    }
    public void controllerFire()
    {
        controllerBtn = true;
    }


    IEnumerator ExampleCoroutine()
    {       
        yield return new WaitForSeconds(1);
        fireEnabled = true;
    }
}
