using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        Debug.Log($"Player damaged! Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    void Die()
    {
        Debug.Log("Player Died 💀");
        if (GameManager.Instance != null)
            GameManager.Instance.PlayerDied();
        else
            gameObject.SetActive(false);
    }
}
