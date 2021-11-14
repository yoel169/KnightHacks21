using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private UIHandler uiHandler;
    public float maxHealth = 100;
    public float currentHealth;
    public int lives = 3;
   // public int shields = 0;
    public float damage = 5;
    public float totalScore = 0;

    float multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        uiHandler = GetComponent<UIHandler>();
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            currentHealth -= other.transform.GetComponent<Enemy>().damage;

            if (currentHealth <= 0)
            {
                lives--;
                uiHandler.UpdateLivesText(lives);

                if (lives <= 0) GameOver();
                else
                {
                    currentHealth = maxHealth;

                }
            }

            uiHandler.UpdateHealthText((int)currentHealth);

            Destroy(other.gameObject);
        }
    }

    private void GameOver()
    {

    }

    public void GiveScore(int scoreToGive)
    {
        totalScore += scoreToGive * multiplier;
        uiHandler.UpdateScoreText((int) totalScore);

        if (totalScore % 5 == 0)
        {
            multiplier += 0.1f;
            uiHandler.UpdateMultiplierText(multiplier);
        }

        if (totalScore % 50 == 0)
        {
            lives++;
            uiHandler.UpdateLivesText(lives);
        }
            
    }

    public void GiveHealth(float health)
    {
        this.currentHealth += health;

        if (currentHealth >= maxHealth) currentHealth = maxHealth;
    }

    public void IncreaseSpeed(float speed)
    {
        GetComponent<Turret>().bulletTime -= speed;
    }

    public void IncreaseDamage(float damage)
    {
        this.damage += damage;
    }

}
