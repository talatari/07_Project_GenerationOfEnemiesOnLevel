using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private GameObject _fish;
    
    private void Start()
    {
        StartCoroutine(SpawnWithDelay());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay()
    {
        WaitForSeconds delaySpawn = new WaitForSeconds(2f);
        
        while (true)
        {
            GameObject fish = Instantiate(_fish, GetRandom(_spawnPoints), Quaternion.identity);

            SetTarget(fish);

            yield return delaySpawn;
        }
    }

    private void SetTarget(GameObject fish)
    {
        if (fish.TryGetComponent(out Movement movementFish))
        {
            movementFish.SetTarget(GetRandom(_targetPoints));
        }
    }

    private Vector3 GetRandom(Transform[] points)
    {
        int mixRange = 1;
        int maxRange = 4;
        int randomIndex = Random.Range(mixRange, maxRange);

        Transform point = points[randomIndex - 1];
        
        return point.transform.position;
    }
}
