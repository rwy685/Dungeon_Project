using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    public CharacterManager CharacterManager { get; private set; }
    public UIManager UIManager { get; private set; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            InitializeManagers();
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void InitializeManagers()
    {
        // CharacterManager 생성
        if (CharacterManager == null)
        {
            var cmObj = new GameObject("CharacterManager");
            CharacterManager = cmObj.AddComponent<CharacterManager>();
            cmObj.transform.SetParent(transform);
        }

        LinkUIManager();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬이 다시 로드되면 UIManager를 새로 연결
        LinkUIManager();
    }

    private void LinkUIManager()
    {
        UIManager = FindObjectOfType<UIManager>();
        if (UIManager != null)
        {
            Debug.Log("[GameManager] UIManager 재연결 완료");
        }
        else
        {
            Debug.LogWarning("[GameManager] 씬에 UIManager가 없습니다.");
        }
    }
}

