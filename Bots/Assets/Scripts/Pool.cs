using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Resource _prefab;
    [SerializeField] private Storage _storage;

    private List<Resource> _pool = new List<Resource>();

    public IEnumerable<Resource> PooledObjects => _pool;

    public Resource GetObject()
    {
        Resource item = null;

        foreach (var checkItem in _pool)
        {
            if (checkItem.isActiveAndEnabled == false)
            {
                item = checkItem;
                _storage.RemoveResource(item);
                break;
            }
        }

        if (item == null)
        {
            item = Object.Instantiate(_prefab);
            _pool.Add(item);
        }

        return item;
    }
}