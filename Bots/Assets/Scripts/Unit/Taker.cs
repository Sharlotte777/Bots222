using UnityEngine;

public class Taker : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Transform _hand;

    private Resource _resource;

    public bool IsGrabbing { get; private set; } = false;

    private void OnEnable()
    {
        _mover.ResourceIsFound += TakeResource;
        _mover.ResourceIsDelivered += PutAwayResource;
    }

    private void OnDisable()
    {
        _mover.ResourceIsFound -= TakeResource;
        _mover.ResourceIsDelivered -= PutAwayResource;
    }

    public void GetResource(Resource resource)
    {
        _resource = resource;
    }
    private void TakeResource()
    {
        IsGrabbing = true;
        _resource.transform.transform.position = _hand.position;
        _resource.transform.parent = transform;
    }

    private void PutAwayResource()
    {
        IsGrabbing = false;
        _resource.ChangeStatus();
        _resource.transform.parent = null;
        _resource.gameObject.SetActive(false);
    }
}
