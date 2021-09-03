using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    //아이템 데이터
    public List<Item> itemDB = new List<Item>();

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }


}
