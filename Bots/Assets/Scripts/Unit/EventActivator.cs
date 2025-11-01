using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class EventActivator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public static readonly int IsRunning = Animator.StringToHash("Run");

    private void Awake() => _animator = GetComponent<Animator>();

    public void TurnOn()
    {
        _animator.SetBool(IsRunning, true);
    }

    public void TurnOff()
    {
        _animator.SetBool(IsRunning, false);
    }
}