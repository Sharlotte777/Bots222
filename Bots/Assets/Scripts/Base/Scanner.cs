using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Storage))]
public class Scanner : MonoBehaviour
{
    private float _delay = 1f;
    private float _radious = 350f;
    private Storage _storage;
    private Sender _sender;

    private void Awake()
    {
        _storage = GetComponent<Storage>();
        _sender = GetComponent<Sender>();
        _sender.SetStorage(_storage);
        StartCoroutine(Scanning());
    }

    private IEnumerator Scanning()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Collider[] objects = Physics.OverlapSphere(transform.position, _radious);

            foreach (Collider obj in objects)
            {
                if (obj.TryGetComponent(out Resource resource))
                {
                    _storage.AddNewResources(resource);
                }
            }

            _sender.SendCoordinates(_storage.ReturnFreeResources());

            yield return wait;
        }
    }
}
