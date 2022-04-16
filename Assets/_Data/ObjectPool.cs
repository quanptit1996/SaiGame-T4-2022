using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int poolCount;

    private List<GameObject> fireballPool = new List<GameObject>();
    private List<GameObject> explosionPool = new List<GameObject>();
    private List<GameObject> enemyPool = new List<GameObject>();
    


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
        for (int i = 0; i < poolCount; i++)
        {
            GameObject obj = Instantiate(fireballPrefab);
            obj.SetActive(false);
            fireballPool.Add(obj);
        }
        for (int i = 0; i < poolCount; i++)
        {
            GameObject obj = Instantiate(explosionPrefab);
            obj.SetActive(false);
            explosionPool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < fireballPool.Count; i++)
        {
            if (!fireballPool[i].activeInHierarchy)
            {
                return fireballPool[i];
            }
        }

        return null;
    }
    
    public GameObject GetPooledExplosion()
    {
        for (int i = 0; i < explosionPool.Count; i++)
        {
            if (!explosionPool[i].activeInHierarchy)
            {
                return explosionPool[i];
            }
        }

        return null;
    }
}
