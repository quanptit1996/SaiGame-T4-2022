using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private GameObject explosionPrefab;
    
    [SerializeField] private GameObject fireballPrefab1;
    [SerializeField] private GameObject explosionPrefab1;
    [SerializeField] private int poolCount;

    private List<GameObject> fireballPool = new List<GameObject>();
    private List<GameObject> explosionPool = new List<GameObject>();
    private List<GameObject> enemyPool = new List<GameObject>();
    
    private List<GameObject> fireballPool1 = new List<GameObject>();
    private List<GameObject> explosionPool1 = new List<GameObject>();
    


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
        
        for (int i = 0; i < poolCount; i++)
        {
            GameObject obj = Instantiate(explosionPrefab1);
            obj.SetActive(false);
            explosionPool1.Add(obj);
        }
    }

    public GameObject GetPooledBullet()
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
    
    public GameObject GetPooledBullet1()
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
    
    public GameObject GetPooledExplosion1()
    {
        for (int i = 0; i < explosionPool1.Count; i++)
        {
            if (!explosionPool1[i].activeInHierarchy)
            {
                return explosionPool1[i];
            }
        }
        return null;
    }
    
    
}
