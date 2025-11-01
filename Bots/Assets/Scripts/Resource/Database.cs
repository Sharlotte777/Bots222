using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Scanner))]
[RequireComponent(typeof(Sender))]
public class Database : MonoBehaviour
{
    private List<Resource> _freeResources;
    private List<Resource> _busyResources;

    private void Awake()
    {
        _freeResources = new List<Resource>();
        _busyResources = new List<Resource>();
    }

    public void AddNewResources(Resource resource)
    {
        if ((_freeResources.Contains(resource) == false) && (_busyResources.Contains(resource) == false))
        {
            _freeResources.Add(resource);
        }
    }

    public void RemoveResource(Resource resource)
    {
        if (_busyResources.Contains(resource))
        {
            _busyResources.Remove(resource);
        }
    }

    public Resource GetFreeResource()
    {
        Resource resource = null;
        int firstIndex = 0;

        if (_freeResources.Count > 0)
        {
            resource = _freeResources[firstIndex];
            _freeResources.Remove(resource);
            _busyResources.Add(resource);
        }

        return resource;
    }
}