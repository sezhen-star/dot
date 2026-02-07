using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static event Action OnPlayerDied;

    [Header("死亡UI")]
    public GameObject deathUI;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // 场景加载时回调，用于重新绑定UI
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // 每次场景加载都会调用
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (deathUI == null)
        {
            deathUI = GameObject.Find("DeathUI"); // 场景里死亡UI的名字
        }
        // 只恢复游戏速度
        Time.timeScale = 1f;
        // 不修改 deathUI
    }

    // 玩家死亡
    public void PlayerDied()
    {
        Debug.Log("【GM】PlayerDied called");

        // 暂停游戏
        Time.timeScale = 0f;

        // 显示UI
        if (deathUI != null)
        {
            deathUI.SetActive(true);
        }

        // 触发事件（如果有其他系统监听）
        OnPlayerDied?.Invoke();
    }

    // 重新开始当前场景
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 返回主菜单
    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // 注意替换成你主菜单场景名
    }
}
