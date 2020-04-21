using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StargateCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject gameManagerGameObject = GameObject.Find("GameManager");
            GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
            gameManager.OnPlayerDeath();
        }
    }
}
