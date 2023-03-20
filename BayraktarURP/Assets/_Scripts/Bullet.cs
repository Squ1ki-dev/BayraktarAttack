using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float life;
    
    private void Awake() 
    {
        Destroy(gameObject, life);
    }
}
