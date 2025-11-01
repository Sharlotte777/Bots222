using System;
using UnityEngine;

public class AppointerTarget : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Taker _taker;

    private float _additionalPositionForZ = 30f;
    private Vector3 _spawnpoint;
    private Vector3 _nullVector = new Vector3(0, 0, 0);
    private Vector3 _targetPosition;
    private bool _goToFlag = false;

    public event Action RobotAtFlag;
    public event Action ResourceFound;
    public event Action ResourceDelivered;

    private void OnEnable()
    {
        _mover.RobotAtTarget += SetTarget;
    }

    private void OnDisable()
    {
        _mover.RobotAtTarget -= SetTarget;
    }

    private void SetTarget()
    {
        if ((transform.position == _spawnpoint) && (_goToFlag == true))
        {
            _goToFlag = false;
            RobotAtFlag?.Invoke();
        }
        else if ((transform.position == _targetPosition) && (!_taker.IsGrabbing))
        {
            ResourceFound?.Invoke();
            _targetPosition = _spawnpoint;
            _mover.SetPosition(_targetPosition);
        }
        else if ((transform.position == _spawnpoint) && (_taker.IsGrabbing))
        {
            ResourceDelivered?.Invoke();
            _targetPosition = _nullVector;
            _mover.SetPosition(_targetPosition);
        }
    }

    public void SetNewBase(Vector3 newBase)
    {
        SetUpSpawnpoint(newBase);
        _spawnpoint.z += _additionalPositionForZ;
        _targetPosition = _spawnpoint;
        ChangeStatusFlag();
    }

    public void SetStartBase(Vector3 newBase) => SetUpSpawnpoint(newBase);

    public void ChangePosition(Vector3 position)
    {
        _targetPosition = position;
        _mover.SetPosition(position);
    }

    private void SetUpSpawnpoint(Vector3 basa)
    {
        _spawnpoint = basa;
        _spawnpoint.z += 5;
        _spawnpoint.y = 0;
    }

    private void ChangeStatusFlag() => _goToFlag = !_goToFlag;
}
