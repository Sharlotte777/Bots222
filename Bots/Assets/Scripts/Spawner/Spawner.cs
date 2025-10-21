using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Pool _pool;

    private float _delay = 5f;

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
            yield return spawnTime;

            Spawn(GetRandomPosition(), out Resource instance);
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
        int minCoordinate = -80;
        int maxCoordinate = 80;
        int coordinateY = 0;
        float randomX = Random.Range(minCoordinate, maxCoordinate);
        float randomZ = Random.Range(minCoordinate, maxCoordinate);

        return new(randomX, coordinateY, randomZ);
    }
}