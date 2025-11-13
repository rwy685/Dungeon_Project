using UnityEngine;

public class Chest : MonoBehaviour
{
    private AnimationHandler anim;

    [Header("Potion Throw")]
    public Transform[] potionSpawnPoints;    // 상자 안 포션위치
    public Rigidbody[] potions;              // 포션리지드바디
    public float throwForce = 3f;

    private void Awake()
    {
        anim = GetComponent<AnimationHandler>();
    }

    public void Open()
    {
        anim.OpenChest();
    }

    // 애니메이션 이벤트용
    public void ThrowPotions()
    {
        for (int i = 0; i < potions.Length; i++)
        {
            Rigidbody rb = potions[i];
            rb.isKinematic = false;

            Vector3 dir = transform.forward + Vector3.up;
            dir.Normalize();// 방향 설정

            rb.AddForce(dir * throwForce, ForceMode.Impulse);
        }
    }
}

