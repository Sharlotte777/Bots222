using UnityEngine;

public class CreatorBase : MonoBehaviour
{
    [SerializeField] private Base _prefab;

    private CreatorText _creatorText;

    public Base Base { get; private set; }

    public void CreateBase(Vector3 position)
    {
        Base = Object.Instantiate(_prefab, position, Quaternion.identity);
        _creatorText = new CreatorText(Base);
        _creatorText.CreateText();
    }
}