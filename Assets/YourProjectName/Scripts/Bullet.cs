using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    float VerticalVelocity = 240;

    // Start is called before the first frame update
    void Start()
    {

        Rigidbody2D bulletRB = GetComponent<Rigidbody2D>();
        float horizontalVelocity = 0;        
        bulletRB.velocity = new Vector2(horizontalVelocity, VerticalVelocity);

    }

   
}
