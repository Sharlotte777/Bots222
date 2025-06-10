using System;
using UnityEngine;

[RequireComponent(typeof(AnimatorController))]
public class ChangerStatus : MonoBehaviour
{
    private AnimatorController _controller;
    private Base _base;

    public event Action ResourceIsFound;
    public event Action StatusChanged;
    public event Action ResourceIsDelivered;

    private void Awake()
    {
        _controller = GetComponent<AnimatorController>();
    }

    public void FindResource() => ResourceIsFound?.Invoke();

    public void DeliverResource(Base basa)
    {
        _base = basa;
        ResourceIsDelivered?.Invoke();
        _controller.SetupRunning(false);
        _base.AddScore();
        StatusChanged?.Invoke();
    }

    public void TurnOnRunning() => _controller.SetupRunning(true);
}
