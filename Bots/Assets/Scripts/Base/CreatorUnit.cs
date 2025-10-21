using UnityEngine;

public class CreatorUnit : MonoBehaviour
{
    [SerializeField] private Robot _unitPrefab;
    [SerializeField] private ControllerOfUnits _controllerOfUnits;

    private float _additionalPositionForZ = 30f;

    public void CreateUnit()
    {
        Vector3 newPosition = transform.position;
        newPosition.z += _additionalPositionForZ;
        newPosition.y = 0;
        Robot _unit = Instantiate(_unitPrefab, newPosition, Quaternion.identity);
        _unit.SetBasesCoordinates(newPosition);
        _controllerOfUnits.AddNewUnit(_unit);
    }
}