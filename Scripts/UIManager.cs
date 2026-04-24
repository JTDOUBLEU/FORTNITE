using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text gameStatusText;
    
    private PlayerHealth playerHealth;
    private bool gameActive = true;

    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player")?.GetComponent<PlayerHealth>();
        if (playerHealth == null)
            Debug.LogError("UIManager: Player not found!");
    }

    void Update()
    {
        if (playerHealth != null && gameActive)
        {
            UpdateHealthDisplay();
        }
    }

    void UpdateHealthDisplay()
    {
        if (healthText != null)
            healthText.text = $"Health: {playerHealth.GetCurrentHealth()}";
    }

    public void ShowGameOver()
    {
        gameActive = false;
        if (gameStatusText != null)
            gameStatusText.text = "GAME OVER";
    }

    public void ShowWin()
    {
        gameActive = false;
        if (gameStatusText != null)
            gameStatusText.text = "YOU WIN!";
    }
}
