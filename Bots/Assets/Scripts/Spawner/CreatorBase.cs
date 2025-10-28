using UnityEngine;

public class CreatorBase : MonoBehaviour
{
    [SerializeField] private Base _prefab;

    private CreatorText _creatorText;

    private Base _base;

    public Base CreateBase(Vector3 position)
    {
        _base = Object.Instantiate(_prefab, position, Quaternion.identity);
        //_creatorText = new CreatorText(_base);
        //_creatorText.CreateText();
        return _base;
    }
}