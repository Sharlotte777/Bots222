using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{
    private List<Robot> _units;

    public void SendCoordinates(Resource resource)
    {
        if (resource.IsTaken == false)
        {
            foreach (var unit in _units)
            {
                if (!unit.IsBusy && !resource.IsTaken)
                {
                    unit.ReceiveResource(resource);
                    unit.ChangeStatus();
                    resource.ChangeStatus();
                }
            }
        }
    }

    public void GetUnits(List<Robot> units) => _units = units;
}
