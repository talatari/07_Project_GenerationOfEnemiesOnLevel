using System.Collections;
using UnityEngine;
using Random = System.Random;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Enemy _enemyPrefab;

    private float _randomDelay;
    private Coroutine _coroutineSpawnEnemy;

    private void Awake() => Initialize();

    private void OnEnable() => 
        _coroutineSpawnEnemy = StartCoroutine(SpawnEnemy());

    private void OnDisable()
    {
        if (_coroutineSpawnEnemy is not null)
            StopCoroutine(_coroutineSpawnEnemy);
    }
    
    private void Initialize()
    {
        int minRange = 2;
        int maxRange = 9;
        Random randomDelay = new Random();
        
        _randomDelay = randomDelay.Next(minRange, maxRange);
    }

    private IEnumerator SpawnEnemy()
    {
        WaitForSeconds delaySpawn = new WaitForSeconds(_randomDelay);
        
        while (true)
        {
            Enemy enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
            
            if (enemy.TryGetComponent(out MovementEnemy movementEnemy))
                movementEnemy.SetTarget(_targetPoint.position);

            yield return delaySpawn;
        }
    }
}