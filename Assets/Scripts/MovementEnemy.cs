using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    
    private Vector3 _target;

    private void Update() => 
        transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime * _speed);
    
    public void SetTarget(Vector3 target) => 
        _target = target;

    
}