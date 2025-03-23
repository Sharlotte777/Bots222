using System;
using UnityEngine;

[RequireComponent(typeof(AnimatorController))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Taker _taker;
    [SerializeField] private Base _base; 
    [SerializeField] private Spawnpoint _spawnpoint;

    private Vector3 _nullVector;
    private Vector3 _targetPosition;
    private AnimatorController _controller;

    public event Action ResourceIsFound;
    public event Action StatusChanged;
    public event Action ResourceIsDelivered;

    private void Awake()
    {
        _controller = GetComponent<AnimatorController>();
        _nullVector = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (_targetPosition != _nullVector)
        {
            if ((transform.position == _targetPosition) && (!_taker.IsGrabbing))
            {
                ResourceIsFound?.Invoke();
                _targetPosition = _spawnpoint.transform.position;
            }
            else if((transform.position == _spawnpoint.transform.position) && (_taker.IsGrabbing))
            {
                ResourceIsDelivered?.Invoke();
                _controller.DeactiveRunning();
                _targetPosition = _nullVector;
                _base.AddScore();
                StatusChanged?.Invoke();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            }
        }
    }

    public void GetPosition(Vector3 position)
    {
        _targetPosition = position;
        _controller.ActiveRunning();
    }
}
