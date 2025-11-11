using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private AnimationHandler anim;

    private void Awake()
    {
        anim = GetComponent<AnimationHandler>();
    }

    public void Open()
    {
        anim.OpenDoor();
        Debug.Log("문 열림");
    }
}
