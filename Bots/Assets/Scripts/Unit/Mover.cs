using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Taker _taker;
    [SerializeField] private ChangerStatus _changerStatus;
    [SerializeField] private Base _startBase; 
    [SerializeField] private Spawnpoint _spawnpoint;

    private Vector3 _nullVector;
    private Vector3 _targetPosition;
    private Base _base;

    private void Awake()
    {
        _base = _startBase;
        _nullVector = new Vector3(0, 0, 0);
    }

    public void SetBase(Base newBase)
    {
        _base = newBase;
    }

    private void Update()
    {
        if (_targetPosition != _nullVector)
        {
            if ((transform.position == _targetPosition) && (!_taker.IsGrabbing))
            {
                _changerStatus.FindResource();
                _targetPosition = _spawnpoint.transform.position;
            }
            else if((transform.position == _spawnpoint.transform.position) && (_taker.IsGrabbing))
            {
                _changerStatus.DeliverResource(_base);
                _targetPosition = _nullVector;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            }
        }
    }

    public void ChangePosition(Vector3 position)
    {
        _targetPosition = position;
        _changerStatus.TurnOnRunning();
    }
}
