using System;
using UnityEngine;

[RequireComponent(typeof(AnimatorController))]
public class ChangerStatus : MonoBehaviour
{
    private AnimatorController _controller;

    public event Action ResourceIsFound;
    public event Action StatusDeliverChanged;
    public event Action ResourceIsDelivered;

    private void Awake()
    {
        _controller = GetComponent<AnimatorController>();
    }

    public void FindResource() => ResourceIsFound?.Invoke();

    public void DeliverResource()
    {
        ResourceIsDelivered?.Invoke();
        _controller.SetupRunning(false);
        StatusDeliverChanged?.Invoke();
    }

    public void TurnOnRunning() => _controller.SetupRunning(true);
}