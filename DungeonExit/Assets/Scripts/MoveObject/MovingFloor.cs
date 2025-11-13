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

    // 플레이어에게 전달할 이동량
    public Vector3 DeltaPosition { get; private set; }
    private Vector3 lastPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }

    private void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.back * moveDistance;
        lastPosition = startPos;
    }

    private void FixedUpdate()
    {
        Vector3 goalPos = movingToTarget ? targetPos : startPos;

        Vector3 nextPos = Vector3.MoveTowards(
            rb.position,
            goalPos,
            moveSpeed * Time.fixedDeltaTime
        );

        // transform.position = nextPos; 제거
        rb.MovePosition(nextPos);   // ← 여기로 변경

        Vector3 delta = nextPos - lastPosition;
        delta.y = 0f;
        DeltaPosition = delta;

        lastPosition = nextPos;

        if (Vector3.Distance(nextPos, goalPos) < 0.05f)
            movingToTarget = !movingToTarget;
    }
}



