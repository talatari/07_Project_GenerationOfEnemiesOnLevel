using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private Fish _fish;

    private Coroutine _coroutineSpawnFish;
    
    private void Start() => _coroutineSpawnFish = StartCoroutine(SpawnFish());

    private void OnDisable()
    {
        if (_coroutineSpawnFish != null)
        {
            StopCoroutine(_coroutineSpawnFish);
        }
    }

    private IEnumerator SpawnFish()
    {
        WaitForSeconds delaySpawn = new WaitForSeconds(2f);
        
        while (true)
        {
            Fish fish = Instantiate(_fish, GetRandomPosition(_spawnPoints), Quaternion.identity);
            SetTarget(fish);

            yield return delaySpawn;
        }
    }

    private void SetTarget(Fish fish)
    {
        if (fish.TryGetComponent(out Movement movementFish))
        {
            Vector3 point = GetRandomPosition(_targetPoints);
            movementFish.SetTarget(point);
        }
    }

    private static Vector3 GetRandomPosition(Transform[] points)
    {
        int randomIndex = Random.Range(0, points.Length);
        Transform point = points[randomIndex];
        
        return point.transform.position;
    }
}
