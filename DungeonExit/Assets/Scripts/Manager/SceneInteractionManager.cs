using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInteractionManager : MonoBehaviour
{
    [SerializeField] private Lever leverDoor;
    [SerializeField] private Door door;
    [SerializeField] private Lever leverChest;
    [SerializeField] private Chest chest;

    private void Start()
    {
        if (leverDoor != null && door != null)
            leverDoor.OnLeverPulled += door.Open;

        if (leverChest != null && chest != null)
            leverChest.OnLeverPulled += chest.Open;
    }
}
