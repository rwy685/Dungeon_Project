using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpPower;
    private Vector2 curMovementInput;
    public LayerMask groundLayerMask;

    private Rigidbody _rigidbody;
    private AnimationHandler animHandler;
    private PlayerCondition condition;

    private float jumpBoost;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        animHandler = GetComponent<AnimationHandler>();
        condition = GetComponent<PlayerCondition>();
    }
    private void Update()
    {
        if(condition.isDead) return;

        bool isMoving = curMovementInput.magnitude > 0.1f;
        bool isGrounded = IsGrounded();

        // AnimationHandler에 상태 전달
        animHandler.UpdateMovementAnimation(isMoving, isGrounded);
    }
    private void FixedUpdate()
    {
        if (condition.isDead) return;
        Move();
    }
    //
    // 입력처리
    //


    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            animHandler.TriggerJump();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 2f))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
                interactable.OnInteract();
        }
    }

    public void OnUseItem1(InputAction.CallbackContext context)
    {
        if(!context.started) return;
        CharacterManager.Instance.Player.inventory.UseItem(0);
    }

    public void OnUseItem2(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        CharacterManager.Instance.Player.inventory.UseItem(1);
    }

    //
    //물리이동 / 점프처리
    //

    private void Move()
    {
        Vector3 dir = new Vector3(curMovementInput.x, 0, curMovementInput.y);

        if (dir.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10f);

            Vector3 moveDir = rotation * Vector3.forward;
            _rigidbody.velocity = moveDir * moveSpeed + Vector3.up * _rigidbody.velocity.y;
        }
        else
        {
            _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
        }
    }
   
    //실제 점프 물리적용(애니메이션 이벤트)
    public void DoJump()
    {
        _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
       {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
       };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.2f, groundLayerMask))
            {
                return true;
            }
        }

        return false;

    }

    public void BoostJump(float value)
    {
        jumpBoost = value;
        jumpPower = jumpPower + jumpBoost;
        StartCoroutine(ResetJumpBoost());
    }

    IEnumerator ResetJumpBoost()
    {
        yield return new WaitForSeconds(5f);
        jumpPower -= jumpBoost;
        jumpBoost = 0f;
    }
    
}
