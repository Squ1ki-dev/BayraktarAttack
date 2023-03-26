using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    [SerializeField] private Transform targetObj;
    [SerializeField] private bool continuousFire = false;
    float period = 0;

    public bool TrySpawnBullet(float deltaTime)
    {
        if (period > 0)
        {
            period -= deltaTime;
            return false;
        }
        period = bulletSpawnPeriod;
        if (continuousFire)
        {
            SpawnBullet();
            return true;
        }
        RaycastHit hit;
        if (Physics.Raycast(_bulletSpawnPoint.position, _bulletSpawnPoint.position.Direction(targetObj.position), out hit, Mathf.Infinity))
        {
            var tank = hit.transform.GetComponent<Tank>();
            if (tank)
            {
                SpawnBullet();
                return true;
            }
        }
        return false;
    }

    public void SpawnBullet()
    {
        var bulletInst = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, transform.rotation);
        bulletInst.GetComponent<Rigidbody>().velocity = _bulletSpawnPoint.position.Direction(targetObj.position) * _bulletSpeed;
    }
}
