using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private List<PoolableMono> poolingList;

    private void Awake()
    {
        instance = this;
        PoolManager.instance = new PoolManager(transform);

        foreach(PoolableMono p in poolingList)
        {
            PoolManager.instance.CreatePool(p, 40);
        }
    }
}
