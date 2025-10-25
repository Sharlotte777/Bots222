using System.Collections.Generic;
using UnityEngine;

public class ControllerOfUnits : MonoBehaviour
{
    [SerializeField] private FlagPlacer _flagPlacer;

    private Vector3 _position;
    private int _radious = 40;
    private List<Robot> _units  = new List<Robot>();

    public int GetCount() => _units.Count;
    public List<Robot> GetUnits() => _units;

    private void Start()
    {
        _position = transform.position;

        Collider[] objects = Physics.OverlapSphere(_position, _radious);

        foreach (Collider obj in objects)
        {
            if (obj.TryGetComponent(out Robot robot))
            {
                _units.Add(robot);
            }
        }
    }

    private void OnEnable()
    {
        if (_units.Count > 0)
        {
            foreach (Robot robot in _units)
            {

            }
        }
    }

    private void OnDisable()
    {
        if (_units.Count > 0)
        {
            foreach (Robot robot in _units)
            {
            }
        }
    }

    public void SendRobotToFlag()
    {
        foreach (Robot robot in _units)
        {
            if (robot.IsBusy == false)
            {
                RemoveUnit(robot, _flagPlacer.Flag.Position);
                robot.ChangeStatus();
                break;
            }
        }
    }

    public void AddNewUnit(Robot robot)
    {
        _units.Add(robot);
    }

    private void RemoveUnit(Robot robot, Vector3 position)
    {
        _units.Remove(robot);
        robot.SetBasesCoordinatesToFlag(position);
    }
}