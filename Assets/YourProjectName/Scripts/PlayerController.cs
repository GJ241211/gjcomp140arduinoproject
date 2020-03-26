using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField]
    float speed = 10f;

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
        rigidbody.AddForce(new Vector2(-horizontalAxis * speed, 0),ForceMode2D.Force);

    }
}
