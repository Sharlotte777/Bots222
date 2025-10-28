using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private Taker _taker;
    [SerializeField] private ChangerStatus _changerStatus;
    [SerializeField] private Mover _mover;
    [SerializeField] private FlagDeleter _flagDeleter;
    [SerializeField] private AppointerTarget _appointerTarget;

    public bool IsBusy { get; private set; } = false;
    public Vector3 Position { get; private set; }

    private void OnEnable()
    {
        _changerStatus.StatusDeliverChanged += ChangeStatus;
        _appointerTarget.RobotAtFlag += ChangeStatus;
        _appointerTarget.ResourceFound += _changerStatus.FindResource;
        _appointerTarget.ResourceDelivered += _changerStatus.DeliverResource;
    }

    private void OnDisable()
    { 
        _changerStatus.StatusDeliverChanged -= ChangeStatus;
        _appointerTarget.RobotAtFlag -= ChangeStatus;
        _appointerTarget.ResourceFound -= _changerStatus.FindResource;
        _appointerTarget.ResourceDelivered -= _changerStatus.DeliverResource;
    }

    public void ReceiveResource(Resource resource)
    {
        _appointerTarget.ChangePosition(resource.transform.position);
        _changerStatus.TurnOnRunning();
        _taker.ChangeResource(resource);
    }

    public void SetBasesCoordinates(Vector3 basePosition)
    {
        _appointerTarget.SetStartBase(basePosition);
    }

    public void SetBasesCoordinatesToFlag(Vector3 basePosition)
    {
        _appointerTarget.SetNewBase(basePosition);
        IsBusy = true;
    }

    public void ChangeStatus()
    {
        IsBusy = !IsBusy;
    }
}