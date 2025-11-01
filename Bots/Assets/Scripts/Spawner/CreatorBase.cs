using UnityEngine;

public class CreatorBase : MonoBehaviour
{
    [SerializeField] private Base _prefab;

    private Base _base;

    public Base CreateBase(Vector3 position)
    {
        _base = Object.Instantiate(_prefab, position, Quaternion.identity);
        return _base;
    }
}