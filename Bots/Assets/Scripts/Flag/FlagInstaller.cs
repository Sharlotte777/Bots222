using UnityEngine;

public class FlagInstaller : MonoBehaviour
{
    private int _numberOfButton = 0;
    private Base _base;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_numberOfButton))
        {
            DetectObject();
        }
    }

    private void DetectObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out Base basa))
            {
                _base = basa;
            }
            else if (hit.collider.gameObject.TryGetComponent(out Plane plane))
            {
                if (_base != null)
                {
                    _base.PlaceFlag(hit.point);
                }
            }
        }
    }
}