using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Object Pool Settings")]
    [SerializeField] private GameObject prefab; 
    [SerializeField] private int poolSize = 10; 

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

   
    public GameObject GetObject(Vector3 position, Quaternion rotation)
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            return obj;
        }
        else
        {
            
            GameObject obj = Instantiate(prefab, position, rotation);
            return obj;
        }
    }


    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}