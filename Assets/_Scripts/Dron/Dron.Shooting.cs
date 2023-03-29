using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Dron
{
    [SerializeField] private Transform targetObj;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float bulletSpawnPeriod;
    float period = 0;
    private RaycastHit _hit;
    private bool alreadyAttacked;

    public bool ShootIfHasTarget<T>()
    {
        if (!alreadyAttacked) return false;
        Invoke(nameof(Recharge), period);

        period = bulletSpawnPeriod;
        RaycastHit hit;
        if (Physics.Raycast(_bulletSpawnPoint.position, _bulletSpawnPoint.position.Direction(targetObj.position), out hit, Mathf.Infinity))
        {
            var tank = hit.transform.GetComponent<T>();
            if (tank != null)
            {
                Shoot();
                return true;
            }
        }
        return false;
    }
    public void Shoot()
    {
        if (!alreadyAttacked) return;
        Invoke(nameof(Recharge), period);

        var bulletInst = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, transform.rotation);
        // bulletInst.GetComponent<Rigidbody>().velocity = _bulletSpawnPoint.position.Direction(targetObj.position) * _bulletSpeed;
        bulletInst.SetTarget(targetObj.position);
    }
    private void Recharge() => alreadyAttacked = false;
}
