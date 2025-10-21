using UnityEngine;

public class Flag : MonoBehaviour
{
    private bool _isPlaced = false;

    public Vector3 Position => transform.position;
    public bool IsPlaced => _isPlaced;

    public void ChangeStatus() => _isPlaced = !_isPlaced;
}