using System.Collections;
using UnityEngine;
using Random = System.Random;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private GameObject _enemyPrefab;

    private float _randomDelay;
    private Coroutine _coroutineSpawnEnemy;

    private void Awake() => Inizialization();

    private void Start() => _coroutineSpawnEnemy = StartCoroutine(SpawnEnemy());

    private void OnDisable()
    {
        if (_coroutineSpawnEnemy != null)
        {
            StopCoroutine(_coroutineSpawnEnemy);
        }
    }
    
    private void Inizialization()
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
            GameObject enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
            
            if (enemy.TryGetComponent(out MovementEnemy movementEnemy))
            {
                movementEnemy.SetTarget(_targetPoint.position);
            }

            yield return delaySpawn;
        }
    }
    
    
}