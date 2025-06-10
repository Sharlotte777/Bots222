using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public static readonly int IsRunning = Animator.StringToHash("Run");

    private void Awake() => _animator = GetComponent<Animator>();

    public void SetupRunning(bool isRunning) => _animator.SetBool(IsRunning, isRunning);
}