using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Dron
{
    [field: SerializeField] public Transform targetObj { get; private set; }
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float targetZoneRadius = 1, bulletSpawnPeriod;
    float period = 0;
    private RaycastHit _hit;
    private bool readyForAttack = true;

    public bool ShootIfHasTarget(Action<Tank> onHit = null)
    {
        if (!readyForAttack) return false;

        period = bulletSpawnPeriod;
        // foreach (var hit in Physics.OverlapSphere(targetObj.position, targetZoneRadius, GameConfigs.Instance.settings.rivalsAISettings.whatIsTarget))//NEED REWRITE LATER
        // {
        //     var tank = hit.transform.GetComponent<Tank>();
        //     if (tank != null && !tank.IsDead)
        //     {
        //         Shoot(tank =>
        //         {
        //             onHit.Invoke(tank);
        //         });
        //         return true;
        //     }
        //     break;
        // }

        RaycastHit hit;
        if (Physics.Raycast(targetObj.position.WithY(100), targetObj.position.WithY(100).Direction(targetObj.position), out hit, Mathf.Infinity))
        {
            var tank = hit.transform.GetComponent<Tank>();
            if (tank != null && !tank.IsDead)
            {
                Shoot(tank =>
                {
                    onHit.Invoke(tank);
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
        bulletInst.SetTarget(targetObj.position, onHit);
        Invoke(nameof(Recharge), period);
    }
    private void Recharge() => readyForAttack = true;
}
