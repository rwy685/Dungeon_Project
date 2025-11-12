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
        rb.isKinematic = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }

    private void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.back * moveDistance; // z축 이동
        lastPosition = startPos;
    }

    private void FixedUpdate()
    {
        Vector3 nextPos = Vector3.MoveTowards(
        transform.position,                      // Transform 직접 이동
        movingToTarget ? targetPos : startPos,
        moveSpeed * Time.fixedDeltaTime
    );

        transform.position = nextPos;

        DeltaPosition = nextPos - lastPosition;
        lastPosition = nextPos;

        if (Vector3.Distance(transform.position, movingToTarget ? targetPos : startPos) < 0.05f)
            movingToTarget = !movingToTarget;
    }


}

