using UnityEngine;

public class Taker : MonoBehaviour
{
    [SerializeField] private Transform _hand;
    [SerializeField] private ChangerStatus _changerStatus;

    private Resource _resource;

    public bool IsGrabbing { get; private set; } = false;

    private void OnEnable()
    {
        _changerStatus.ResourceIsFound += TakeResource;
        _changerStatus.ResourceIsDelivered += PutAwayResource;
    }

    private void OnDisable()
    {
        _changerStatus.ResourceIsFound -= TakeResource;
        _changerStatus.ResourceIsDelivered -= PutAwayResource;
    }

    public void ChangeResource(Resource resource)
    {
        _resource = resource;
    }

    private void TakeResource()
    {
        if (_resource != null)
        {
            IsGrabbing = true;
            _resource.transform.transform.position = _hand.position;
            _resource.transform.parent = transform;
        }
    }

    private void PutAwayResource()
    {
        IsGrabbing = false;
        _resource.transform.parent = null;
    }
}