using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;

    private Dictionary<string, Pool<PoolableMono>> _pools = new Dictionary<string, Pool<PoolableMono>>();
    private Transform _parentTrm;

    public PoolManager(Transform parentTrm)
    {
        _parentTrm = parentTrm;
    }

    public void CreatePool(PoolableMono prefab, int cnt = 10) 
    {
        Pool<PoolableMono> pool = new Pool<PoolableMono>(prefab, _parentTrm, cnt);
        _pools.Add(prefab.gameObject.name, pool);
    }

    public PoolableMono Pop(string prefabName)
    {
        if (_pools.ContainsKey(prefabName) == false)
        {
            Debug.LogError("스텍 없음");
            return null;    
        }

        PoolableMono item = _pools[prefabName].Pop();
        item.Reset();
        return item;
    }

    public void Push(PoolableMono obj)
    {
        obj.gameObject.SetActive(false);
        _pools[obj.name].Push(obj);
    }
}
