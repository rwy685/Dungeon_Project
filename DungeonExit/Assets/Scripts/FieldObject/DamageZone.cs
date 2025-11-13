using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float knockbackForce = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //체력감소
            var player = collision.collider.GetComponent<PlayerCondition>();
            if (player != null)
            {
                player.TakeDamage(damageAmount);
            }
            //넉백
            Rigidbody playerRb = collision.collider.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 knockDir = (collision.collider.transform.position - transform.position).normalized;
                knockDir.x = 4f;
                knockDir.y = 1.5f;

                playerRb.AddForce(knockDir * knockbackForce, ForceMode.Impulse);
            }

            Debug.Log($"{damageAmount} 받음!");
        }
    }
}
