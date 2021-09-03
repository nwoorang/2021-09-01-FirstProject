using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float JumpForce;
    public float MaxJumpCount;//2개까지만 기본적으로
    float JumpCount;

    [SerializeField] private Animator pAnimator;
    [SerializeField] private Rigidbody2D pRig2D;
    private void Start()
    {
        JumpCount = 0;
    }

    private void FixedUpdate()//바닥판정
    {
        Debug.DrawRay(pRig2D.position - new Vector2(0,0.5f), Vector3.down/2, new Color(0,0.5f, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(pRig2D.position-new Vector2(0, 0.5f), Vector3.down,0.5f, LayerMask.GetMask("Ground"));

        if (pRig2D.velocity.y < 0)
        {
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    pAnimator.SetBool("Jump", false);
                    if (JumpCount == MaxJumpCount)//최대 점프 횟수를 넘었다면
                    {
                        JumpCount = 0;//점프누적횟수가 초기화 되어서 다시 점프를 할수있게 된다.
                    }
                }
            }
        }
    }

    public void OnClick()//클릭할때마다
    {

        JumpMethod();
            pAnimator.SetBool("Jump", true);

    }

    public void JumpMethod()
    {
        if (JumpCount < MaxJumpCount)//점프 최대횟수 제한
        {
            pRig2D.velocity = Vector2.zero;

        pRig2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            JumpCount++;
        }
    }
}
