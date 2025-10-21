using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sender : MonoBehaviour
{
    private List<Robot> _units = new List<Robot>();
    private Storage _storage;

    public Sender(Storage storage)
    {
        _storage = storage;
    }

    public void AddUnit(Robot newUnit)
    {
        if (_units != null)
        {
            if (_units.Contains(newUnit) == false)
            {
                _units.Add(newUnit);
            }
        }
        else
        {
            _units.Add(newUnit);
        }
    }

    public void DistributeCoordinates(List<Resource> resources)
    {
        int countOfResources = resources.Count;
        int indexOfFirst = 0;

        if (_units != null)
        {
            List <Robot> freeRobots = _units.Where(x => x.IsBusy == false).ToList();
            int countOfUnits = freeRobots.Count;

            if (freeRobots.Count > 0)
            {
                int randomIndex = Random.Range(indexOfFirst, countOfUnits);

                if (countOfResources > 0)
                {
                    Robot unit = freeRobots[randomIndex];
                    Resource resource = resources[indexOfFirst];
                    unit.ReceiveResource(resource);
                    unit.ChangeStatus();
                    _storage.AddResource(resource);
                    countOfResources--;
                }
            }
        }
    }
}