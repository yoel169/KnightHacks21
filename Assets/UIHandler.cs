using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text healthText;
    public Text livesText;
    public Text scoreText;
    public Text multiplierText;
    public GameObject multiplierPanel;
    public Text difficultyText;
    public Text timerText;

    private bool multiplierIsOn = false;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
       // multiplayerPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timerText.text =  " Seconds \n " + ((int) time).ToString();
    }



    public void UpdateHealthText(int health)
    {
        healthText.text = "Health \n " + health.ToString();
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score \n " + score.ToString();
    }

    public void UpdateLivesText(int lives)
    {
        livesText.text = "Lives \n " + lives.ToString();
    }

    public void UpdateMultiplierText(float multiplier)
    {
        multiplierText.text = "Multiplier \n X" + multiplier.ToString();
    }

    public void ToggleMultiplier()
    {
        multiplierIsOn = !multiplierIsOn;
        multiplierPanel.SetActive(multiplierIsOn);
    }

    public void UpdateDifficulty(int diff)
    {
        difficultyText.text = "Difficulty \n " + diff.ToString();
    }
}
