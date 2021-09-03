using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/Consumable/Health")]
public class ItemHealingEft : ItemEffect
{
    public int healingPoint = 0;
    public override bool ExecuteRole()
    {
        Debug.Log("힐링포션 사용함");
        if(PlayerState.instance.maxhp > PlayerState.instance.hp)
        {
            PlayerState.instance.hp += healingPoint;

            if(PlayerState.instance.maxhp < PlayerState.instance.hp)
            {
                int sum = PlayerState.instance.hp - PlayerState.instance.maxhp;

                PlayerState.instance.hp -= sum;
            }
        }
        return true;
    }

}
