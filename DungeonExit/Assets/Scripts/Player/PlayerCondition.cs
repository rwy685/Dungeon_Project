using System;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    private AnimationHandler animHandler;
    public bool isDead { get; private set; } = false;

    Condition health { get { return uiCondition.health; } }

    public event Action onTakeDamage;

    private void Awake()
    {
        animHandler = GetComponent<AnimationHandler>();
    }

    private void Update()
    {
        if (health.curValue <= 0f && !isDead)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (isDead) return;
        health.Add(amount);
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        animHandler.PlayDeath();

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;
        health.Subtract(amount);
        onTakeDamage?.Invoke();

        if (health.curValue <= 0f)
        {
            Die();
        }
        Debug.Log($"현재 체력: {health.curValue} / {health.maxValue}");
    }
}
