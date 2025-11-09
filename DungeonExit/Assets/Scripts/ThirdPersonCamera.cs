using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private float lookHeight;
    public Transform target;
    public Vector3 offset;
    public float followSpeed = 10f;
    public float rotateSpeed = 5f;

    private float currentX;
    private float currentY;
    public float sensitivity = 2f;
    public float minY = -30f;
    public float maxY = 60f;
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Start()
    {
        if (target == null) return;

        // 카메라가 타겟 기준으로 얼마나 떨어져있는지 계산해서 offset 재설정
        Vector3 targetpos = target.position + Vector3.up * lookHeight;

        //씬 기준 offset 자동계산
        offset = transform.position - targetpos;

        // 현재 카메라의 회전 각도 저장
        Vector3 dir = (transform.position - targetpos).normalized;
        Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);
        Vector3 angles = rot.eulerAngles;

        currentX = angles.y;
        currentY = angles.x > 180f ? angles.x - 360f : angles.x;
    }



    private void LateUpdate()
    {
        if (target == null) return;

        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY += Input.GetAxis("Mouse Y") * sensitivity;
        currentY = Mathf.Clamp(currentY, minY, maxY);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        //카메라 기본거리
        Vector3 targetpos = target.position + Vector3.up * lookHeight;
        Vector3 desiredPos = targetpos + rotation * offset;

        //충돌 감지용 Raycast
        Vector3 direction = (desiredPos - targetpos).normalized;
        float distance = Vector3.Distance(targetpos, desiredPos);

        //Player 레이어 무시
        int mask = ~LayerMask.GetMask("Player");
        RaycastHit hit;

        if (Physics.Raycast(targetpos, direction, out hit, distance, mask))
        {
            // 벽에 닿았으면 충돌 지점 바로 앞에 카메라를 두기
            transform.position = hit.point - direction * 0.3f;
        }
        else
        {
            // 부드럽게 따라가기
            transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * followSpeed);
        }

        transform.LookAt(targetpos);

    }
}
