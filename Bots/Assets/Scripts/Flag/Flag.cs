using UnityEngine;

public class Flag : MonoBehaviour
{
    private bool _placed;

    public Vector3 Position => transform.position;
    public bool Placed => _placed;

    public void Remove() 
    {
        _placed = false;
    }

    public void Place()
    {
        _placed = true;
    }
}