using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100;
    public float currentHealth;
    public float HealthPerSec;
    public GameOverScreen GameOverScreen;
    public GameController points;
    public bool GameOver = false;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        HealthPerSec = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth += HealthPerSec * Time.deltaTime;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(currentHealth <= 0)
        {
            GameOver = true;
            Destroy(gameObject);
            GameOverScreen.Setup(points.SetPoints);
        }
        healthBar.slider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
