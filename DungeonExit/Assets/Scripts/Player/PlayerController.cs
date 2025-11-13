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
    private MovingFloor currentFloor;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.interpolation = RigidbodyInterpolation.Interpolate; 
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous; 

        animHandler = GetComponent<AnimationHandler>();
        condition = GetComponent<PlayerCondition>();
    }

    private void Update()
    {
        if (condition.isDead) return;

        bool isMoving = curMovementInput.magnitude > 0.1f;
        bool isGrounded = IsGrounded();
        animHandler.UpdateMovementAnimation(isMoving, isGrounded);
    }

    private void FixedUpdate()
    {
        if (condition.isDead) return;
        Move();
        ApplyMovingFloor();
    }

    // 입력 처리
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            curMovementInput = context.ReadValue<Vector2>();
        else if (context.phase == InputActionPhase.Canceled)
            curMovementInput = Vector2.zero;
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
        if (!context.started) return;
        CharacterManager.Instance.Player.inventory.UseItem(0);
    }

    public void OnUseItem2(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        CharacterManager.Instance.Player.inventory.UseItem(1);
    }

    // 이동 처리
    private void Move()
    {
        Vector3 dir = new Vector3(curMovementInput.x, 0, curMovementInput.y);

        if (dir.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.fixedDeltaTime * 10f);

            Vector3 moveDir = rotation * Vector3.forward;

            Vector3 platformVel = Vector3.zero;
            if (currentFloor != null)
                platformVel = currentFloor.DeltaPosition / Time.fixedDeltaTime;

            // JumpFloor AddForce 보호
            float oldY = _rigidbody.velocity.y;

            Vector3 horizontalVel = moveDir * moveSpeed + platformVel;

            // 벽체크 용
            if (!IsGrounded() && IsHittingWall())
            {
                horizontalVel = Vector3.zero;
            }

            _rigidbody.velocity =
                new Vector3(horizontalVel.x, oldY, horizontalVel.z);
        }
        else
        {
            Vector3 platformVel = Vector3.zero;
            if (currentFloor != null)
                platformVel = currentFloor.DeltaPosition / Time.fixedDeltaTime;

            float oldY = _rigidbody.velocity.y;

            _rigidbody.velocity =
                new Vector3(platformVel.x, oldY, platformVel.z);
        }
    }

    // 점프 물리 적용 (애니메이션 이벤트에서 호출)
    public void DoJump()
    {
        _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    // 바닥 체크
    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.3f, groundLayerMask))
                return true;
        }
        return false;
    }

    // 벽 체크
    bool IsHittingWall()
    {
        // 플레이어의 이동 방향이 없으면 벽 체크할 필요 없음
        if (curMovementInput == Vector2.zero)
            return false;

        // 플레이어의 ‘회전 방향’을 기준으로 앞쪽으로 레이 발사
        Vector3 dir = transform.forward;

        // 캐릭터 위치 약간 위에서 쏘면 바닥 충돌과 구분됨
        Vector3 origin = transform.position + Vector3.up * 0.5f;

        // 벽 체크 거리 (조금만 체크)
        float distance = 0.3f;

        // 벽이 groundLayerMask에 포함돼 있다면 해당 레이어 사용
        if (Physics.Raycast(origin, dir, distance, groundLayerMask))
        {
            return true;
        }

        return false;
    }


    // 점프 버프
    public void BoostJump(float value)
    {
        jumpBoost = value;
        jumpPower += jumpBoost;
        StartCoroutine(ResetJumpBoost());
    }

    IEnumerator ResetJumpBoost()
    {
        yield return new WaitForSeconds(5f);
        jumpPower -= jumpBoost;
        jumpBoost = 0f;
    }

    // 플랫폼 감지
    void ApplyMovingFloor()
    {
        currentFloor = null;

        Ray ray = new Ray(transform.position + Vector3.up * 0.3f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.6f, groundLayerMask))
        {
            var floor = hit.collider.GetComponent<MovingFloor>();
            if (floor != null)
            {
                currentFloor = floor;
            }
        }
    }
}

