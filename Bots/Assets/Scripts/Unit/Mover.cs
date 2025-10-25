using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Taker _taker;

    private float _speed = 70;
    private float _additionalPositionForZ = 30f;
    private Vector3 _spawnpoint;
    private Vector3 _nullVector = new Vector3(0, 0, 0);
    private Vector3 _targetPosition;
    private bool _goToFlag = false;

    public event Action RobotAtFlag;
    public event Action ResourceFound;
    public event Action ResourceDelivered;

    private void Update()
    {
        if (_targetPosition != _nullVector)
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
            }
            else if((transform.position == _spawnpoint) && (_taker.IsGrabbing))
            {
                ResourceDelivered?.Invoke();
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
        SetUpSpawnpoint(newBase);
        _spawnpoint.z += _additionalPositionForZ;
        _targetPosition = _spawnpoint;
        ChangeStatusFlag();
    }

    public void SetStartBase(Vector3 newBase) => SetUpSpawnpoint(newBase);

    public void ChangePosition(Vector3 position)
    {
        _targetPosition = position;
    }

    public void ChangeStatusFlag() => _goToFlag = !_goToFlag;

    private void SetUpSpawnpoint(Vector3 basa)
    {
        _spawnpoint = basa;
        _spawnpoint.z += 5;
        _spawnpoint.y = 0;
    }
}