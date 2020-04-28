using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    
    void Start()
    {
        scoreText.text = string.Format("Your Score Was: {0:0.00}", (PlayerPrefs.GetFloat("score")));
    }

   
}
