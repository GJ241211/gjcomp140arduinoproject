using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StargateScript : MonoBehaviour
{
    [SerializeField]
    GameObject Barrier;
    [SerializeField]
    GameObject Gate;

    // Start is called before the first frame update
    void Start()
    {
        spawnStargate();
    }

    
    void spawnStargate()
    {

        Rigidbody2D SarGateRB = GetComponent<Rigidbody2D>();
        float horizontalVelocity = (0);
        float verticalVelocity = (-80);
        SarGateRB.velocity = new Vector2(horizontalVelocity, verticalVelocity);

        int Gate1Index = Random.Range(0, 5);
        int Gate2Index = Random.Range(0, 5);
        while (Gate1Index == Gate2Index)
        {
            if (Gate1Index == Gate2Index)
            {
                Gate2Index = Random.Range(0, 5);
            }
        }

        Vector3 startPos = transform.position;
        for (int i = 0; i < 6; i++)
        {
            if (i == Gate1Index || i == Gate2Index)
            {
                Instantiate<GameObject>(Gate, startPos, Quaternion.identity, transform);
            }
            else
            {
                Instantiate<GameObject>(Barrier, startPos, Quaternion.identity, transform);
            }
            startPos.x += 320;
        }

    }

    public void destroyStargate()
    {
        Destroy(gameObject);
    }
}
