using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField, Range(1, 50)] private int _timeLife = 7;
    
    private void Start() => 
        Destroy(gameObject, _timeLife);
    
    
}