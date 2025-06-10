using System;
using UnityEngine;

[RequireComponent(typeof(ChangerStatus))]
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
    //private AnimatorController _controller;

    //public event Action ResourceIsFound;
    //public event Action StatusChanged;
    //public event Action ResourceIsDelivered;

    private void Awake()
    {
        _base = _startBase;
        //_controller = GetComponent<AnimatorController>();
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
                //ResourceIsFound?.Invoke();
                _targetPosition = _spawnpoint.transform.position;
            }
            else if((transform.position == _spawnpoint.transform.position) && (_taker.IsGrabbing))
            {
                _changerStatus.DeliverResource(_base);
                //ResourceIsDelivered?.Invoke();
                //_controller.SetupRunning(false);
                _targetPosition = _nullVector;
                //_base.AddScore();
                //StatusChanged?.Invoke();
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
        //_controller.SetupRunning(true);
    }
}
