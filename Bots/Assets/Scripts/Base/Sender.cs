using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sender : MonoBehaviour
{
    private List<Robot> _units = new List<Robot>();
    private Database _storage;

    public Sender(Database storage)
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

    public void DistributeCoordinates()
    {
        int indexOfFirst = 0;

        if (_units != null)
        {
            List <Robot> freeRobots = _units.Where(x => x.IsBusy == false).ToList();
            int countOfUnits = freeRobots.Count;

            if (freeRobots.Count > 0)
            {
                int randomIndex = Random.Range(indexOfFirst, countOfUnits);
                Resource resource = _storage.GetFreeResource();

                if (resource != null)
                {
                    Robot unit = freeRobots[randomIndex];
                    unit.ReceiveResource(resource);
                    unit.ChangeStatus();
                }
            }
        }
    }
}