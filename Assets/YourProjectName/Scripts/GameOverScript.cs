using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = string.Format("Your Score Was: {0:0.00}", (PlayerPrefs.GetFloat("score")));
    }

   
}
