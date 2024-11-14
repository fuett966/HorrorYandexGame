using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : Component
{
    private Queue<T> pool = new Queue<T>();
    private T prefab;

    public ObjectPool(T prefab, int initialSize = 10)
    {
        this.prefab = prefab;
        for (int i = 0; i < initialSize; i++)
        {
            AddObjectToPool();
        }
    }

    // Создаем объект и добавляем в пул
    private void AddObjectToPool()
    {
        T obj = Object.Instantiate(prefab);
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }

    // Получаем объект из пула
    public T GetObject()
    {
        if (pool.Count == 0)
        {
            AddObjectToPool();
        }

        T obj = pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    // Возвращаем объект в пул
    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}