using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Taker))]
[RequireComponent(typeof(ChangerStatus))]
public class Robot : MonoBehaviour
{
    private Mover _mover;
    private Taker _taker;
    private ChangerStatus _changerStatus;

    public bool IsBusy { get; private set; } = false;

    private void OnEnable() => _changerStatus.StatusDeliverChanged += ChangeStatus;

    private void OnDisable() => _changerStatus.StatusDeliverChanged -= ChangeStatus;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _taker = GetComponent<Taker>();
        _changerStatus = GetComponent<ChangerStatus>();
    }

    public void ReceiveResource(Resource resource)
    {
        _mover.ChangePosition(resource.transform.position);
        _taker.ChangeResource(resource);
    }

    public void ChangeStatus() => IsBusy = !IsBusy;
}
