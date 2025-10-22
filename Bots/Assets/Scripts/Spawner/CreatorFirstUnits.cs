using UnityEngine;

public class CreatorFirstUnits : MonoBehaviour
{
    private Robot _unitPrefab;
    private Base _base;
    private float _additionalPositionForZ = 30f;
    private Robot _unit = null;

    public CreatorFirstUnits(Robot robot, Base basa)
    {
        _unitPrefab = robot;
        _base = basa;
    }

    public void CreateFirstUnits()
    {
        CreateUnit();
        CreateUnit();
        CreateUnit();
    }

    private void CreateUnit()
    {
        Vector3 newPosition = _base.transform.position;
        newPosition.z += _additionalPositionForZ;
        newPosition.y = 0;
        _unit = Instantiate(_unitPrefab, newPosition, Quaternion.identity);
        _unit.SetBasesCoordinates(newPosition);
    }
}