using UnityEngine;

public class FlagDeleter : MonoBehaviour
{
    [SerializeField] private AppointerTarget _appointer;
    [SerializeField] private CreatorBase _creator;
    [SerializeField] private LayerMask _layerMask;

    private int _radious = 50;

    private void OnEnable()    
    {
        _appointer.RobotAtFlag += DeleteFlag;
    }

    private void OnDisable()
    {
        _appointer.RobotAtFlag -= DeleteFlag;
    }

    public void DeleteFlag()
    {
        Collider[] objects = Physics.OverlapSphere(transform.position, _radious, _layerMask);

        foreach (Collider obj in objects)
        {
            if (obj.TryGetComponent(out Flag flag))
            {
                _creator.CreateBase(flag.Position);
                flag.Remove();
                flag.gameObject.SetActive(false);
            }
        }
    }
}