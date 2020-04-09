using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField]
    float speed = 10f * Time.deltaTime;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        //rigidbody.velocity = new Vector2(-horizontalAxis * speed, 0);
        //rigidbody.AddForce(new Vector2(-horizontalAxis * speed, 0),ForceMode2D.Force);
        transform.position += Vector3.left * Input.GetAxis("Horizontal") * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            int rotateAmmount = 45;
            Destroy(collision.gameObject);
            transform.eulerAngles += Vector3.forward * rotateAmmount;
            transform.eulerAngles += Vector3.forward * -rotateAmmount;
        }
    }
}
