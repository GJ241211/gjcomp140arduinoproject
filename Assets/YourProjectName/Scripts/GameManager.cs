using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    float score;
    [SerializeField]
    Image[] ShotLights;
    
    // calculates and displays score
    void Update()
    {
        score = Time.timeSinceLevelLoad * 5;
        scoreText.text = string.Format("Score: {0:0.00}",(score));        
    }
    public float GetScore()
    {
        return score;
    }

    //Wends score to game over screen
    public void OnPlayerDeath()
    {
        PlayerPrefs.SetFloat("score", GetScore());
        PlayerPrefs.Save();
        SceneManager.LoadScene("GameOver");
    }

    public void ToggleLight(int lightIndex)
    {
        //changes lights (ingame hud objects) visability/ Linked to fire bullet to get shots count 
        lightIndex--;
        if (lightIndex < ShotLights.Length)
        {
            Color lightColor = ShotLights[lightIndex].color;
            if (lightColor.a < 1.0f)
            {
                lightColor.a = 1.0f;
            }
            else
            {
                lightColor.a = 0.0f;
            }
            ShotLights[lightIndex].color = lightColor;
        }
    }
}
