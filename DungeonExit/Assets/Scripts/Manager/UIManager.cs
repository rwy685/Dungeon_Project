using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Restart UI")]
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        // 미리 꺼두기
        if (restartPanel != null)
            restartPanel.SetActive(false);

        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ShowRestartButton()
    {
        if (restartPanel != null)
        {
            restartPanel.SetActive(true);
            EnableCursor(true);
        }
        else
        {
            Debug.LogWarning("[UIManager] restartPanel이 연결되어 있지 않습니다.");
        }
    }

    private void EnableCursor(bool visible)
    {
        Cursor.visible = visible;
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}

