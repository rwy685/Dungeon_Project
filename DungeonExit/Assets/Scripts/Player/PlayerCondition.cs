using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }

    public event Action onTakeDamage;

    private void Update()
    {
        if (health.curValue <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Die()
    {
        Debug.Log("사망");
    }

    public void TakeDamage(float amount)
    {
        health.Subtract(amount);
        onTakeDamage?.Invoke();

        if (health.curValue <= 0f)
        {
            Die();
        }
        Debug.Log($"현재 체력: {health.curValue} / {health.maxValue}");
    }
}
