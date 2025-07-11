using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Scanner))]
[RequireComponent(typeof(Sender))]
public class Storage : MonoBehaviour
{
    private List<Resource> _freeResources;
    private List<Resource> _busyResources;

    private void Awake()
    {
        _freeResources = new List<Resource>();
        _busyResources = new List<Resource>();
    }

    public List<Resource> GetFreeResources() => new List<Resource>(_freeResources);

    public void AddNewResources(Resource resource)
    {
        if ((_freeResources.Contains(resource) == false) && (_busyResources.Contains(resource) == false))
        {
            _freeResources.Add(resource);
        }
    }

    public void ChangeResourcesStatus(Resource resource)
    {
        if (_freeResources.Contains(resource))
        {
            _freeResources.Remove(resource);
            _busyResources.Add(resource);
        }
        else if (_busyResources.Contains(resource))
        {
            _busyResources.Remove(resource);
        }
    }
}
