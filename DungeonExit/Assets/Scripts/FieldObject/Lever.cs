using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    private AnimationHandler anim;
    [SerializeField] private AnimationHandler doorAnim;

    private void Start()
    {
        anim = GetComponent<AnimationHandler>();
    }
    public void LeverControl(InputAction.CallbackContext context)
    {
        anim.LeverPull();

        StartCoroutine(OpenDoorAfterDelay(1.0f));
    }

    IEnumerator OpenDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (doorAnim != null)
        {
            doorAnim.OpenDoor();
        }
    }
}
