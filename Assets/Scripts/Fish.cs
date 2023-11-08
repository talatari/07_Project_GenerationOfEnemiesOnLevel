using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField, Range(1, 100)] private int _timeLife = 10;
    
    private void Start() => Destroy(gameObject, _timeLife);
}
