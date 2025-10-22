using System.Collections.Generic;
using UnityEngine;

public class ControllerOfUnits : MonoBehaviour
{
    [SerializeField] private FlagPlacer _flagPlacer;

    private Vector3 _position;
    private int _radious = 40;

    public List<Robot> Units { get; private set; } = new List<Robot>();
    public int GetCount() => Units.Count;

    private void Start()
    {
        _position = transform.position;

        Collider[] objects = Physics.OverlapSphere(_position, _radious);

        foreach (Collider obj in objects)
        {
            if (obj.TryGetComponent(out Robot robot))
            {
                Units.Add(robot);
            }
        }
    }

    public void SendRobotToFlag()
    {
        foreach (Robot robot in Units)
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
        Units.Add(robot);
    }

    private void RemoveUnit(Robot robot, Vector3 position)
    {
        Units.Remove(robot);
        robot.SetBasesCoordinatesToFlag(position);
    }
}