using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    private AnimationHandler anim;
    public Action OnLeverPulled;


    private void Start()
    {
        anim = GetComponent<AnimationHandler>();
    }

    //레버 당기고 1초 뒤에 문 열리도록 지연
    public void LeverControl(InputAction.CallbackContext context)
    {
        anim.LeverPull();

        StartCoroutine(InvokeAfterDelay(1.0f));
    }

    IEnumerator InvokeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        OnLeverPulled?.Invoke(); 
    }
}
