using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private float speed;
    private Vector3 target;
    private Action<Tank> onHit;
    private void Awake()
    {
        Destroy(gameObject, life);
    }
    private void FixedUpdate()
    {
        transform.MoveToTarget(target, Time.fixedDeltaTime * speed);
    }
    public void SetTarget(Vector3 target, Action<Tank> onHit = null)
    {
        transform.LookAt(target);
        this.target = target;
        this.onHit = onHit;
    }
    private void OnTriggerEnter(Collider other)
    {
        var tank = other.GetComponent<Tank>();
        if(tank && !tank.IsDead) 
        {
            tank.Kill();
            onHit?.Invoke(tank);
            Destroy(gameObject);
        }
    }
}
