using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidCollision : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -300);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -300);

        }

        if (collision.gameObject.tag == "Player")
        {
            GameObject gameManagerGameObject = GameObject.Find("GameManager");
            GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
            gameManager.OnPlayerDeath();
        }
    }

}
