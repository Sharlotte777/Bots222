using System.Collections;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    private float _delay = 1f;
    private float _radious = 350f;
    private Sender _sender;

    private void Awake()
    {
        StartCoroutine(Scanning());
    }

    public void GetSender(Sender sender) => _sender = sender;

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
                    _sender.SendCoordinates(resource);
                }
            }

            yield return wait;
        }
    }
}
