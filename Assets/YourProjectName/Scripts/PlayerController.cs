using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField]
    float speed = 10f;
    float startPos = 0f;     //first reading taken from the gyro to determin the mid

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        //get controller reference x,y,z (to calibrate gyro)        
    }

    private void getStartPos(float Z)
    {
        startPos = Z;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        //rigidbody.velocity = new Vector2(-horizontalAxis * speed, 0);
        //rigidbody.AddForce(new Vector2(-horizontalAxis * speed, 0),ForceMode2D.Force);
        transform.position += Vector3.left * horizontalAxis * speed * Time.deltaTime;


        //Get updated position of controller

        //check for button press (maybe indipendently in fire bullet?)
    }


    public void updateMovement(float Z)
    {

        Debug.Log(Z);

        Z = Z - startPos; // account for the start rotation so future cals are simpler

        if (30>Z)
        {
            //left speed max use -30

        }
        else if (30<Z)
        {
            //right speed max use 30

        }
        else
        {
            //speed isnt maxed (use calculation that will be % of max speed) Use Z
            transform.position += Vector3.left * Z * speed * Time.deltaTime ;

        }
        //transform.position += Vector3.left * horizontalAxis * speed * Time.deltaTime;

        transform.position += Vector3.left * Z * speed * Time.deltaTime * 0.15f;

        // end movement with - startPos
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            int rotateAmmount = 45;
            Destroy(collision.gameObject);
            transform.eulerAngles += Vector3.forward * rotateAmmount;
            transform.eulerAngles += Vector3.forward * -rotateAmmount;
            //Invoke()
        }
    }
}
