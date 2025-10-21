using System.Collections;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Base _basa;

    private float _delay = 1f;
    private float _radious = 60f;

    private void Awake()
    {
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
                    resource.gameObject.SetActive(false);
                    _basa.AddScore();
                }
            }

            yield return wait;
        }
    }
}
