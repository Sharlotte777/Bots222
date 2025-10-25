using UnityEngine;

public class Flag : MonoBehaviour
{
    private bool _Placed = false;

    public Vector3 Position => transform.position;
    public bool Placed => _Placed;

    public void ChangeStatusOfPlacement() => _Placed = !_Placed;
}