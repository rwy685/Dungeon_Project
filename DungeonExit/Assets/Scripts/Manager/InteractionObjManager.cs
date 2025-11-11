using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjManager : MonoBehaviour
{
    [SerializeField] private Lever leverDoor;
    [SerializeField] private Door door;
    [SerializeField] private Lever leverChest;
    [SerializeField] private Chest chest;

    private void Start()
    {
        // 이벤트 연결
        if (leverDoor != null && door != null)
            leverDoor.OnLeverPulled += door.Open;

        if (leverChest != null && chest != null)
            leverChest.OnLeverPulled += chest.Open;

        Debug.Log("레버-문, 레버-상자 연결 완료");
    }
}
