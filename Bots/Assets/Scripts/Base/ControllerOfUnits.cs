using System.Collections.Generic;
using UnityEngine;

public class ControllerOfUnits : MonoBehaviour
{
    [SerializeField] private Collector _collector;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Base _basa;

    private Vector3 _position;
    private int _radious = 40;
    private List<Robot> _units  = new List<Robot>();

    public int GetCount() => _units.Count;

    private void Start()
    {
        _position = transform.position;

        Collider[] objects = Physics.OverlapSphere(_position, _radious, _layerMask);

        foreach (Collider obj in objects)
        {
            if (obj.TryGetComponent(out Robot robot))
            {
                _units.Add(robot);
                robot.ObjectDelivered += _collector.TakeObject;
            }
        }
    }

    public void SendRobotToFlag()
    {
        foreach (Robot robot in _units)
        {
            if (robot.IsBusy == false)
            {
                RemoveUnit(robot, _basa.GetFlagPosition());
                robot.ChangeStatus();
                break;
            }
        }
    }

    public void AddNewUnit(Robot robot)
    {
        _units.Add(robot);
        robot.ObjectDelivered += _collector.TakeObject;
    }

    private void RemoveUnit(Robot robot, Vector3 position)
    {
        _units.Remove(robot);
        robot.SetBasesCoordinatesToFlag(position);
        robot.ObjectDelivered -= _collector.TakeObject;
    }
}