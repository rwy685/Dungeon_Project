using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private void Awake()
    {
        var gm = GameManager.Instance;  // GameManager 강제 생성
    }
}
