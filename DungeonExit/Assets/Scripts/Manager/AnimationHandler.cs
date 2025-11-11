using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator anim;
    private PlayerController playerController;
    private Rigidbody rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }

    // 이동 관련 애니메이션 갱신
    public void UpdateMovementAnimation(bool isMove, bool isGround)
    {
        anim.SetBool("IsMove", isMove);
        anim.SetBool("IsGround", isGround);
    }

    // 점프 트리거
    public void TriggerJump()
    {
        anim.SetTrigger("Jump");
    }

    // 애니메이션 이벤트에서 호출됨
    public void OnJumpEvent()
    {
        playerController.DoJump(); // 물리 처리 위임
    }

    // 사망 트리거
    public void PlayDeath()
    {
        anim.SetTrigger("Dead");
    }

    // 루트모션 제어 (착지 타이밍 처리)
    private void OnAnimatorMove()
    {
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);

        if (state.IsName("Jump_Land"))
        {
            float t = state.normalizedTime;
            anim.applyRootMotion = (t >= 0.7f);
        }
        else
        {
            anim.applyRootMotion = false;
        }
    }

    public void OpenDoor()
    {
        Debug.Log("문 열기 트리거 작동");
        anim.SetTrigger("Open");
    }

    public void LeverPull()
    {
        anim.SetTrigger("LeverPull");
    }

}

