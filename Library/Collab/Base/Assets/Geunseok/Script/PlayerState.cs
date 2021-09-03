using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    #region Singleton
    public static PlayerState playerstate;
    private void Awake()
    {
        if (playerstate != null)
        {
            Destroy(gameObject);
            return;
        }
        playerstate = this;
    }

    #endregion

    [SerializeField]
    State startState;

    public int maxhp;
    public int hp;
    public float damage;
    public float speed;
    public float dash;
    public float jump;
    public float money;

    private void Start()
    {
        maxhp = startState.maxhp;
        hp = startState.maxhp;
        damage = startState.damage;
        speed = startState.speed;
        dash = startState.dash;
        jump = startState.jump;
        money = startState.money;
    }
    void Update()
    {
        
    }
}
