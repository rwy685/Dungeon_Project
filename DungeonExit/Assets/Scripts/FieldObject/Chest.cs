using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private AnimationHandler anim;

    private void Awake()
    {
        anim = GetComponent<AnimationHandler>();
    }

    public void Open()
    {
        anim.OpenChest();
        Debug.Log("상자 열림");
    }
}
