using UnityEngine;

public class FlagPlacer : MonoBehaviour
{
    [SerializeField] private Flag _flagPrefab;

    public Flag Flag { get; private set; } = new Flag();

    public void PlaceFlag(Vector3 position)
    {
        position.y = 0;
        Flag = Instantiate(_flagPrefab, position, Quaternion.identity);
        Flag.ChangeStatusOfPlacement();
    }

    public void MoveFlag(Vector3 position)
    {
        Flag.gameObject.SetActive(true);
        int positionY = 0;
        position.y = positionY;
        Flag.transform.position = position;
    }
}
