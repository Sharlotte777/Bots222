using UnityEngine;

public class Resource : MonoBehaviour
{
    public bool IsTaken {  get; private set; } = false;

    public void ChangeStatus()
    {
        IsTaken = !IsTaken;
    }
}
