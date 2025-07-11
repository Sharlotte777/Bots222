using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Pool _pool;

    private float _delay = 3f;

    private void OnEnable()
    {
        StartCoroutine(Spawning());
    }

    private void OnDisable()
    {
        StopCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds spawnTime = new(_delay);

        while (enabled)
        {
            Spawn(GetRandomPosition(), out Resource instance);

            yield return spawnTime;
        }
    }

    private void Spawn(Vector3 position, out Resource instance)
    {
        instance = _pool.GetObject();
        instance.transform.position = position;
        instance.gameObject.SetActive(true);
    }

    private Vector3 GetRandomPosition()
    {
        int minCoordinate = -60;
        int maxCoordinate = 60;
        int coordinateY = 2;
        float randomX = Random.Range(minCoordinate, maxCoordinate);
        float randomZ = Random.Range(minCoordinate, maxCoordinate);

        return new(randomX, coordinateY, randomZ);
    }
}
