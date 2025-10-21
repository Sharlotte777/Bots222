using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private Taker _taker;
    [SerializeField] private ChangerStatus _changerStatus;
    [SerializeField] private Mover _mover;
    [SerializeField] private FlagDeleter _flagDeleter;

    public bool IsBusy { get; private set; } = false;
    public Vector3 Position { get; private set; }

    private void OnEnable()
    {
        _changerStatus.StatusDeliverChanged += ChangeStatus;
        _mover.RobotAtFlag += ChangeStatus;
    }

    private void OnDisable()
    { 
        _changerStatus.StatusDeliverChanged -= ChangeStatus;
        _mover.RobotAtFlag -= ChangeStatus;
    }

    public void ReceiveResource(Resource resource)
    {
        _mover.ChangePosition(resource.transform.position);
        _taker.ChangeResource(resource);
    }

    public void SetBasesCoordinates(Vector3 basePosition)
    {
        _mover.SetStartBase(basePosition);
    }

    public void SetBasesCoordinatesToFlag(Vector3 basePosition)
    {
        _mover.SetNewBase(basePosition);
        IsBusy = true;
    }

    public void ChangeStatus() => IsBusy = !IsBusy;
}