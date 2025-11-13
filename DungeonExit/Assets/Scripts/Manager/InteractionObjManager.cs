using UnityEngine;

public class InteractionObjManager : MonoBehaviour
{
    private void Start()
    {

        Lever[] allLevers = FindObjectsOfType<Lever>(true);

        foreach (var lever in allLevers)
        {
            // 레버의 부모 오브젝트를 기준으로 탐색
            Transform parent = lever.transform.parent;

            if (parent == null)
                continue;

            // 같은 부모에 Door가 있는지 탐색
            Door door = parent.GetComponentInChildren<Door>();
            if (door != null)
            {
                lever.OnLeverPulled += door.Open;

                continue;   // 문을 찾았으면 상자를 찾을 필요 없음
            }

            // 같은 부모에 Chest가 있는지 탐색
            Chest chest = parent.GetComponentInChildren<Chest>();
            if (chest != null)
            {
                lever.OnLeverPulled += chest.Open;

                continue;
            }

            Debug.LogWarning($"[경고] {lever.name}는 Door/Chest를 찾을 수 없음");
        }
    }
}

