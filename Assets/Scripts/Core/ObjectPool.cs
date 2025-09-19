using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Object Pool Settings")]
    [SerializeField] private GameObject prefab; // Prefab a ser instanciado no pool
    [SerializeField] private int poolSize = 10; // Tamanho inicial do pool

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        // Inicializa o pool com objetos desativados
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    // Obtém um objeto do pool
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
            // Se o pool estiver vazio, instancia um novo objeto
            GameObject obj = Instantiate(prefab, position, rotation);
            return obj;
        }
    }

    // Retorna um objeto ao pool
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}