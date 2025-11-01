using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _speed = 70;
    private Vector3 _nullVector = new Vector3(0, 0, 0);
    private Vector3 _targetPosition;

    public event Action RobotAtTarget;

    private void Update()
    {
        if (_targetPosition != _nullVector)
        {
            if (transform.position == _targetPosition)
            {
                RobotAtTarget?.Invoke();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            }
        }
    }

    public void SetPosition(Vector3 position)
    {
        _targetPosition = position;
    }
}