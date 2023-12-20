using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthSlider;
    private int currentHealth = 100;
    private int maxHealth = 100;

    void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpdateHealthBar();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
    }
}