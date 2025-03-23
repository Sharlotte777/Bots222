using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private Resource _prefab;
    private Queue<Resource> _pool;

    public Pool(Resource prefab)
    {
        _pool = new();
        _prefab = prefab;
    }

    public Resource GetObject()
    {
        if (_pool.Count == 0)
        {
            Resource instance = Object.Instantiate(_prefab/*, _case*/);

            return instance;
        }

        return _pool.Dequeue();
    }
}
