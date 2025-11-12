using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingFloor : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveDistance = 3f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingToTarget = true;

    private Rigidbody rb;

    // 이동량을 플레이어에게 알려주기 위한 변수
    public Vector3 DeltaPosition { get; private set; }
    private Vector3 lastPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.back * moveDistance; // z축 이동
        lastPosition = startPos;
    }

    private void FixedUpdate()
    {
        // 다음 위치 계산
        Vector3 nextPos = Vector3.MoveTowards(rb.position,
                                              movingToTarget ? targetPos : startPos,
                                              moveSpeed * Time.fixedDeltaTime);
        // 이동
        rb.MovePosition(nextPos);

        // 이동량 계산 (플레이어 보정용)
        DeltaPosition = nextPos - lastPosition;
        lastPosition = nextPos;

        // 도착 시 방향 반전
        if (Vector3.Distance(rb.position, movingToTarget ? targetPos : startPos) < 0.05f)
            movingToTarget = !movingToTarget;
    }

}

