using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{
    [SerializeField] private Base _startBase;

    private List<Robot> _units;
    private Base _base;
    private Storage _storage;

    private void Awake()
    {
        SetBase(_startBase);
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

    public void DistributeCoordinates(List<Resource> resources)
    {
        int countOfResources = resources.Count;
        int indexOfFirstResource = 0;

        foreach (var unit in _units)
        {
            if (countOfResources > 0)
            {
                if (!unit.IsBusy)
                {
                    Resource resource = resources[indexOfFirstResource];
                    unit.ReceiveResource(resource);
                    unit.ChangeStatus();
                    _storage.AddResource(resource);
                    countOfResources--;
                }
            }
        }
    }
}
