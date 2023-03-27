using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private float speed;
    private Vector3 target;
    private void Awake()
    {
        Destroy(gameObject, life);
    }
    private void FixedUpdate()
    {
        transform.MoveToTarget(target, Time.fixedDeltaTime * speed);
    }
    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }
}
