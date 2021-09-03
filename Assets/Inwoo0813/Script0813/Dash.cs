using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private float DashForce;
    public float MaxDashCount;//2개까지만 기본적으로
    float DashCount;
    public static float DashDir;
    [SerializeField] private Animator pAnimator;
    [SerializeField] private Rigidbody2D pRig2D;

    private void Start()
    {
        DashDir = 1;
        DashCount = 0;

    }
    //public 
    public void OnClick()//클릭할때마다
    {
        
        DashMethod();
        pAnimator.SetBool("Dash", true);

    }

    public void DashMethod()
    {
        if (DashCount < 1000)//대쉬 최대횟수 제한
        {
            pRig2D.velocity = Vector2.zero;

            pRig2D.AddForce(new Vector2(DashDir * DashForce,0), ForceMode2D.Impulse);
            DashCount++;
        }
    }

}
