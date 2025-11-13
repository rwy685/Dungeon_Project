using UnityEngine;

public class JumpFloor : MonoBehaviour
{
    public float jumpPower = 10f;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                Debug.Log("JumpFloor impulse applied");

            }
        }
    }

}
