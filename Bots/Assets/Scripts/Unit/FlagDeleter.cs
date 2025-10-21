using UnityEngine;

public class FlagDeleter : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private CreatorBase _creator;

    private int _radious = 50;

    private void OnEnable()    
    {
        _mover.RobotAtFlag += DeleteFlag;
    }

    private void OnDisable()
    {
        _mover.RobotAtFlag -= DeleteFlag;
    }

    public void DeleteFlag()
    {
        Collider[] objects = Physics.OverlapSphere(transform.position, _radious);

        foreach (Collider obj in objects)
        {
            if (obj.TryGetComponent(out Flag flag))
            {
                _creator.CreateBase(flag.Position);
                flag.ChangeStatus();
                flag.gameObject.SetActive(false);
            }
        }
    }
}