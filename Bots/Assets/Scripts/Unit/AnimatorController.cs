using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ActiveRunning()
    {
        _animator.SetBool("Run", true);
    }

    public void DeactiveRunning()
    {
        _animator.SetBool("Run", false);
    }
}
