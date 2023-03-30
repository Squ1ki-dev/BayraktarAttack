using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Dron
{
    [SerializeField] private Transform targetObj;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float bulletSpawnPeriod;
    float period = 0;
    private RaycastHit _hit;
    private bool readyForAttack = true;

    public bool ShootIfHasTarget<T>(Action<T> onHit = null)
    {
        if (!readyForAttack) return false;

        period = bulletSpawnPeriod;
        RaycastHit hit;
        if (Physics.Raycast(_bulletSpawnPoint.position, _bulletSpawnPoint.position.Direction(targetObj.position), out hit, Mathf.Infinity))
        {
            var tank = hit.transform.GetComponent<T>();
            if (tank != null)
            {
                Shoot(transform =>
                {
                    var hitedTarget = transform.GetComponent<T>();
                    if (hitedTarget != null)
                        onHit.Invoke(hitedTarget);
                });
                return true;
            }
        }
        return false;
    }
    public void Shoot(Action<Tank> onHit)
    {
        if (!readyForAttack) return;
        readyForAttack = false;
        var bulletInst = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, transform.rotation);
        // bulletInst.GetComponent<Rigidbody>().velocity = _bulletSpawnPoint.position.Direction(targetObj.position) * _bulletSpeed;
        bulletInst.SetTarget(targetObj.position, onHit);
        Invoke(nameof(Recharge), period);
    }
    private void Recharge() => readyForAttack = true;
}
