using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonComponent : MonoBehaviour
{

	private static SingletonComponent instance;

	public static SingletonComponent Instance
	{
		get
		{
			if (instance == null)
			{
				var obj = FindObjectOfType<SingletonComponent>();
				if (obj != null)
				{
					instance = obj;
				}
				else
				{
					var newObj = new GameObject().AddComponent<SingletonComponent>();
					instance = newObj;
				}
			}
			return instance;
		}
	}

	public int testnum = 0;
	//호출할때는         SingletonComponent.Instance.testnum += 2;
	private void Awake()
	{
		var objs = FindObjectsOfType<SingletonComponent>();
		if (objs.Length != 1)
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
	}
}
