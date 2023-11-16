using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _multiplier;
    [SerializeField] private Rigidbody _prefabBullet;
    [SerializeField] private Transform _objectToShoot;

    private Coroutine _coroutineShooting;
    
    private void OnEnable() => 
        _coroutineShooting = StartCoroutine(ShootingWorker());

    private void OnDisable()
    {
        if (_coroutineShooting is not null)
            StopCoroutine(_coroutineShooting);
    }

    private IEnumerator ShootingWorker()
    {
        bool isWork = true;
        float timeWaitShooting = 3f;
        
        while (isWork)
        {
            Vector3 vector3Direction = (_objectToShoot.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_prefabBullet, transform.position + vector3Direction, Quaternion.identity);

            newBullet.transform.up = vector3Direction;
            newBullet.velocity = vector3Direction * _multiplier;
            
            yield return new WaitForSeconds(timeWaitShooting);
        }
    }
    
    
}