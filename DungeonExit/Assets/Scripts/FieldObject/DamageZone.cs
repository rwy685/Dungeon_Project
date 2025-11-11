using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float knockbackForce = 5f;

    private void OnTriggerEnter(Collider collider)
    {
       
        if (collider.CompareTag("Player"))
        {   
            //체력감소
            var player = collider.GetComponent<PlayerCondition>();
            if (player != null)
            {
                player.TakeDamage(damageAmount);
            }
           //넉백
            Rigidbody playerRb = collider.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 knockDir = (collider.transform.position - transform.position).normalized;
                knockDir.x = 4f;
                knockDir.y = 1.5f;

                playerRb.AddForce(knockDir * knockbackForce, ForceMode.Impulse);
            }

            Debug.Log($"{damageAmount} 받음!");
        }
    }
}
