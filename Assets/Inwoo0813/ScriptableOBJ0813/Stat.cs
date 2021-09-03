using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Stat", menuName = "Scriptable Object/Stat", order = int.MaxValue)]
public class Stat : ScriptableObject 
{
    [SerializeField]
    private string name;
    public string Name { get { return name; } }
    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } }
    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }
    [SerializeField]
    private float sightRange;
    public float SightRange { get { return sightRange; } }
    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }

    [SerializeField]
    private float teststat;
    public float Teststat { get { return teststat; } }

}
