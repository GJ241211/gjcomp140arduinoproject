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

    
    void Update()
    {

        if (shots > 0 && fireEnabled == true) //checks if you can currently fire
        {
            if (Input.GetKeyDown("space") || controllerBtn == true) // checks if inputs are calling to fire
            {
                //Turn of the light before moving the shot counter down!
                gameManager.ToggleLight(shots);
                ShootBullet();
                shots--;
                Debug.Log("current shot" + shots);
                controllerBtn = false;

                fireEnabled = false;
                StartCoroutine(ExampleCoroutine()); //starts fire cooldown
                
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

    //identifies if vontroller button is pressed.
    public void controllerFire()
    {
        controllerBtn = true;
    }


    IEnumerator ExampleCoroutine() //starts a cooldown between shots to prevent players shooting all there shots with 1 press on the controller
    {       
        yield return new WaitForSeconds(0.6f);
        fireEnabled = true;
    }
}
