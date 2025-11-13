using UnityEngine;
using UnityEngine.SceneManagement;
public class ClearObject : MonoBehaviour
{
    public void ReStartScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
