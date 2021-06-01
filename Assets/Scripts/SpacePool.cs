using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPoolItem
{
    //Can now add multiple powerups to the pool to be instantiated with tags
    [Tooltip("The object to pool.")] public GameObject objectToPool;
    [Tooltip("The initial amount to spawn.")] public int amountToPool;
    [Tooltip("When the initial amount of objects have been used, do you want to spawn more?")] public bool shouldExpand;
}
public class SpacePool : MonoBehaviour
{
    [Header("Bullet")]
    public static SpacePool pool;
    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;
    public Transform firePoint;

    //[Header("Asteroids")]
    
    
    private void Awake()
    {
        pool = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = Instantiate(item.objectToPool, firePoint);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    /// <summary>
    /// Objects with tag specified will be spawned when this method is called.
    /// </summary>
    public GameObject GetPooledObject(string _tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == _tag)
            {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            //Expand the pool for powerups and stuff
            if (item.objectToPool.tag == _tag)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = Instantiate(item.objectToPool, firePoint);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }
}

