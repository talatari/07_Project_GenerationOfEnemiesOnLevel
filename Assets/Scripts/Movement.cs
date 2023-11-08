using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 _target;

    public void SetTarget(Vector3 target) => _target = target;

    private void Update() => 
        transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime);
}
