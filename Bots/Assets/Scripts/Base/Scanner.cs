using System.Collections;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    private float _delay = 1f;
    private float _radious = 350f;
    private Storage _storage;
    private Sender _sender;

    private void Awake()
    {
        _storage = GetComponent<Storage>();
        _sender = new Sender(_storage);
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
                else if (obj.TryGetComponent(out Robot robot))
                {
                    _sender.AddUnit(robot);
                }
            }

            _sender.DistributeCoordinates(_storage.GetFreeResources());

            yield return wait;
        }
    }
}
