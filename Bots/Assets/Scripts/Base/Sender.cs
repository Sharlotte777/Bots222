using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Storage))]
public class Sender : MonoBehaviour
{
    [SerializeField] private Base _startBase;

    private List<Robot> _units;
    private Base _base;
    private Storage _storage;

    private void Awake()
    {
        _base = _startBase;
        _units = _base.GetUnits();
    }

    public void SetBase(Base newBase)
    {
        _base = newBase;
    }

    public void SetStorage(Storage storage)
    {
        _storage = storage;
    }

    public void SendCoordinates(List<Resource> resources)
    {
        Resource resource = new Resource();
        int countOfResources = resources.Count;
        int indexOfFirstResource = 0;

        foreach (var unit in _units)
        {
            if (countOfResources > 0)
            {
                if (!unit.IsBusy)
                {
                    resource = resources[indexOfFirstResource];
                    unit.ReceiveResource(resource);
                    unit.ChangeStatus();
                    _storage.ChangeResourcesStatus(resource);
                    countOfResources--;
                }
            }
        }
        //if (resource.IsTaken == false)
        //{
        //    foreach (var unit in _units)
        //    {
        //        if (!unit.IsBusy && !resource.IsTaken)
        //        {
        //            unit.ReceiveResource(resource);
        //            unit.ChangeStatus();
        //        }
        //    }
        //}
    }
}
