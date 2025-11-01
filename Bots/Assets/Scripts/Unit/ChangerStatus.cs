using System;
using UnityEngine;

[RequireComponent(typeof(EventActivator))]
public class ChangerStatus : MonoBehaviour
{
    private EventActivator _controller;

    public event Action ResourceIsFound;
    public event Action StatusDeliverChanged;
    public event Action ResourceIsDelivered;

    private void Awake()
    {
        _controller = GetComponent<EventActivator>();
    }

    public void FindResource() => ResourceIsFound?.Invoke();

    public void DeliverResource()
    {
        ResourceIsDelivered?.Invoke();
        _controller.TurnOff();
        StatusDeliverChanged?.Invoke();
    }

    public void TurnOnRunning()
    {
        _controller.TurnOn();
    }
}