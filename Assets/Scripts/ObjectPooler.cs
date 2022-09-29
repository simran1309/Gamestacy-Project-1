using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectPooler : MonoBehaviour
{
[System.Serializable]
public class Pool
{

	public GameObject  prefab;
	public string Tag;
	public int  size;

	
}

	public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
	void Start()
	{
       foreach (Pool pool  in pools)
       {
        
       Queue<GameObject> ObjectPool= new Queue<GameObject>();
		poolDictionary= new Dictionary<string,Queue<GameObject>> ();


		for (int i = 0; i <pools.Count; i++)
		{
			GameObject obj= Instantiate(pool.prefab);
            obj.SetActive(false);
            ObjectPool.Enqueue(obj);
		}
        poolDictionary.Add(pool.Tag,ObjectPool);
       }
	}
}