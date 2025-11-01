using System.Collections;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Base _basa;
    [SerializeField] LayerMask _layerMask;

    private float _delay = 1f;
    private float _radious = 60f;

    public void TakeObject()
    {
        Collider[] objects = Physics.OverlapSphere(transform.position, _radious, _layerMask);

        foreach (Collider obj in objects)
        {
            if (obj.TryGetComponent(out Resource resource))
            {
                resource.gameObject.SetActive(false);
                _basa.AddScore();
            }
        }
    }
}
