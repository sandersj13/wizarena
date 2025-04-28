using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Image healthBarFill;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    public void TakeDamage (int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void UpdateHealthBar()
    {
        float fillAmount = (float)currentHealth / maxHealth;
        healthBarFill.fillAmount = fillAmount;
    }

    void Die()
    {
        Debug.Log("Player died!");

        Destroy(gameObject);
    }



}