using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject PlayerPos;
    public Vector3 vec3;
    private void FixedUpdate()
    {
        this.gameObject.transform.position = PlayerPos.transform.position+vec3;
    }
}
