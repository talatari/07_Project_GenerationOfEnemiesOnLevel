using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _multiplier;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private Transform _objectToShoot;

    private Coroutine _coroutineShooting;
    
    private void Start() => _coroutineShooting = StartCoroutine(ShootingWorker());

    private void OnDisable() => StopCoroutine(_coroutineShooting);

    private IEnumerator ShootingWorker()
    {
        bool isWork = true;
        
        while (isWork)
        {
            Vector3 vector3Direction = (_objectToShoot.position - transform.position).normalized;
            GameObject newBullet = Instantiate(_prefab, transform.position + vector3Direction, Quaternion.identity);

            if (newBullet.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.transform.up = vector3Direction;
                rigidbody.velocity = vector3Direction * _multiplier;
            }
            
            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}