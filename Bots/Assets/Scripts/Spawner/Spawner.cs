using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Pool _pool;
    [SerializeField] private Storage _storage;

    private float _delay = 5f;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Spawning());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds spawnTime = new(_delay);

        while (enabled)
        {
            yield return spawnTime;

            Spawn(GetRandomPosition());
        }
    }

    private void Spawn(Vector3 position)
    {
        Resource instance = _pool.GetObject();
        _storage.RemoveResource(instance);
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