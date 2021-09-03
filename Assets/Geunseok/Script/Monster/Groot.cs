using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groot : MonoBehaviour
{

    private void Awake()
    {
        
    }
    public void Attack()
    {
        gameObject.tag = "Monster";
    }

    public void AttackEnd()
    {
        gameObject.tag = "Untagged";
    }

    public void AttackAniEnd()
    {
        transform.GetComponentInParent<Monster>().Groot_Attack_End();
        Destroy(gameObject);
    }
}
