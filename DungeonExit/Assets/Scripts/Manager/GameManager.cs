using System;
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
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);

            // 씬 매니저 호출
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //씬 로드 후 SceneInteractionManager 확인

        var interactionManager = FindObjectOfType<SceneInteractionManager>();

        if (interactionManager == null)
        {
            //없을 시 생성
            GameObject obj = new GameObject("SceneInteractionmanager");
            interactionManager = obj.AddComponent<SceneInteractionManager>();
            Debug.Log("SceneInteractionManager 생성");
        }
        else
        {
            Debug.Log("SceneInteractionManger 이미 있음");
        }
    }
    //현재 신에 생성안되고있음
}
