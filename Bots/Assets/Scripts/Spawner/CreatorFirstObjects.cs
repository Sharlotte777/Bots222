using UnityEngine;

public class CreatorFirstObjects : MonoBehaviour
{
    [SerializeField] private CreatorBase _creatorBase;
    [SerializeField] private Robot _unitPrefab;

    private CreatorFirstUnits _creatorUnits;
    private Vector3 startPosition = new Vector3(150, 0, -48);

    private void Awake()
    {
         _creatorUnits = new CreatorFirstUnits(_unitPrefab, _creatorBase.CreateBase(startPosition));
        _creatorUnits.CreateFirstUnits();
    }
}