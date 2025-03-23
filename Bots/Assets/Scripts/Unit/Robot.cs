using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Taker))]
public class Robot : MonoBehaviour
{
    private Mover _mover;
    private Taker _taker;

    public bool IsBusy { get; private set; } = false;

    private void OnEnable()
    {
        _mover.StatusChanged += ChangeStatus;
    }

    private void OnDisable()
    {
        _mover.StatusChanged -= ChangeStatus;
    }

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _taker = GetComponent<Taker>();
    }

    public void ReceiveResource(Resource resource)
    {
        _mover.GetPosition(resource.transform.position);
        _taker.GetResource(resource);
    }

    public void ChangeStatus()
    {
        IsBusy = !IsBusy;
    }
}
