using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void PlayerDied()
    {
        Debug.Log("Game Over 💀");
        Time.timeScale = 0f;
        Invoke("ReloadScene", 2f);
    }

    public void WinGame()
    {
        Debug.Log("You Win 🏆");
        Time.timeScale = 0f;
    }

    void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
