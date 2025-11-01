using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Database))]
public class Scanner : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private float _delay = 1f;
    private float _radious = 350f;
    private Database _storage;
    private Sender _sender;

    private void Awake()
    {
        _storage = GetComponent<Database>();
        _sender = new Sender(_storage);
        StartCoroutine(Scanning());
    }

    private IEnumerator Scanning()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Collider[] objects = Physics.OverlapSphere(transform.position, _radious, _layerMask);

            foreach (Collider obj in objects)
            {
                if (obj.TryGetComponent(out Resource resource))
                {
                    _storage.AddNewResources(resource);
                }
                else if (obj.TryGetComponent(out Robot robot))
                {
                    _sender.AddUnit(robot);
                }
            }

            _sender.DistributeCoordinates();

            yield return wait;
        }
    }
}
