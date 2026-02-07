using UnityEngine;

public class DeathUIController : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        GameManager.OnPlayerDied += Show;
    }

    void OnDisable()
    {
        GameManager.OnPlayerDied -= Show;
    }

    void Show()
    {
        gameObject.SetActive(true);
    }

    // ∞¥≈•”√
    public void Restart()
    {
        GameManager.Instance.RestartGame();
    }

    public void BackToMenu()
    {
        GameManager.Instance.BackToMainMenu();
    }
}
