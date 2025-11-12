using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class ClearObject : MonoBehaviour
{
    public void ReStartScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
