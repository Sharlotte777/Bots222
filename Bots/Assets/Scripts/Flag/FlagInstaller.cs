using UnityEngine;

public class FlagInstaller : MonoBehaviour
{
    private Base _base;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckObject();
        }
    }

    private void CheckObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.TryGetComponent<Base>(out Base basa))
            {
                _base = basa;
            }
            else if (hit.collider.gameObject.TryGetComponent<Plane>(out Plane plane))
            {
                if (_base != null)
                {
                    _base.SetFlag(hit.point);
                }
            }
        }
    }
}