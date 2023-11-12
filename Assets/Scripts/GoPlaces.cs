using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private Transform[] _allPoints;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private int _index;
    
    private void Start() => Initialization();

    private void Update()
    {
        Transform target = _allPoints[_index];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            NextPlaceTakerLogic();
        }
    }
    
    private void Initialization()
    {
        _allPoints = new Transform[_target.childCount];

        for (int i = 0; i < _target.childCount; i++)
        {
            if (_target.GetChild(i).TryGetComponent(out Transform transform))
            {
                _allPoints[i] = transform;
            }
        }
    }
    
    private void NextPlaceTakerLogic()
    {
        _index++;

        if (_index == _allPoints.Length)
            _index = 0;

        Vector3 thisPointVector = _allPoints[_index].transform.position;
        transform.forward = thisPointVector - transform.position;
    }
}