using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Taker _taker;
    [SerializeField] private ChangerStatus _changerStatus;

    private float _speed = 70;
    private float _additionalPositionForZ = 30f;
    private Vector3 _spawnpoint;
    private Vector3 _nullVector = new Vector3(0, 0, 0);
    private Vector3 _targetPosition;
    private Vector3 _base;
    private bool _toFlag = false;

    public event Action RobotAtFlag;

    private void Update()
    {
        if (_targetPosition != _nullVector)
        {
            if ((transform.position == _spawnpoint) && (_toFlag == true))
            {
                _toFlag = false;
                RobotAtFlag?.Invoke();
            }
            else if ((transform.position == _targetPosition) && (!_taker.IsGrabbing))
            {
                _changerStatus.FindResource();
                _targetPosition = _spawnpoint;
            }
            else if((transform.position == _spawnpoint) && (_taker.IsGrabbing))
            {
                _changerStatus.DeliverResource();
                _targetPosition = _nullVector;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            }
        }
    }

    public void SetNewBase(Vector3 newBase)
    {
        SetBase(newBase);
        _spawnpoint.z += _additionalPositionForZ;
        _targetPosition = _spawnpoint;
        ChangeStatusFlag();
    }

    public void SetStartBase(Vector3 newBase) => SetBase(newBase);

    public void ChangePosition(Vector3 position)
    {
        _targetPosition = position;
        _changerStatus.TurnOnRunning();
    }

    public void ChangeStatusFlag() => _toFlag = !_toFlag;

    private void SetUpSpawnpoint()
    {
        _spawnpoint = _base;
        _spawnpoint.z += 5;
        _spawnpoint.y = 0;
    }

    private void SetBase(Vector3 newBase)
    {
        _base = newBase;
        SetUpSpawnpoint();
    }
}