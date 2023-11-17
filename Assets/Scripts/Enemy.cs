using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Range(1, 50)] private int _timeLife = 7;
    
    private void Start() => 
        Destroy(gameObject, _timeLife);
    
    
}