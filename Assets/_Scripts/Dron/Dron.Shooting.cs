using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Partial definition of the 'Dron'(Shooting) class.
public partial class Dron
{
    // Serialized field for the target object transform.
    [field: SerializeField] public Transform targetObj { get; private set; }
    // Serialized field for the bullet spawn point transform.
    [SerializeField] private Transform _bulletSpawnPoint;
    // Serialized field for the bullet prefab to be instantiated.
    [SerializeField] private Bullet _bulletPrefab;
    // Serialized field for the radius of the target zone. // Serialized field for the period between bullet spawns.
    [SerializeField] private float targetZoneRadius = 1, bulletSpawnPeriod;

    // Internal variable to track the time period.
    float period = 0;
    // RaycastHit variable to store information about the hit.
    private RaycastHit _hit;
    // Boolean flag indicating whether the drone is ready to attack.
    private bool readyForAttack = true;

    // Method to shoot if the drone has a target within the target zone.
    public bool ShootIfHasTarget(Action<Tank> onHit = null)
    {
        // Check if the drone is ready to attack.
        if (!readyForAttack) return false;

        // Reset the period for bullet spawn
        period = bulletSpawnPeriod;

        // Raycast to check for a target within the target zone
        RaycastHit hit;
        if (Physics.Raycast(targetObj.position.WithY(100), targetObj.position.WithY(100).Direction(targetObj.position), out hit, Mathf.Infinity))
        {
            var tank = hit.transform.GetComponent<Tank>();
            // If a valid tank is found and it's not dead, initiate the shoot.
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
    
    // Method to initiate a shoot action with a callback on hit.
    public void Shoot(Action<Tank> onHit)
    {
        // Check if the drone is ready to attack.
        if (!readyForAttack) return;
        
        // Set the drone to not ready for further attacks until recharged.
        readyForAttack = false;
        // Instantiate a bullet at the bullet spawn point.
        var bulletInst = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, transform.rotation);
        // Set the target and on-hit callback for the bullet.
        bulletInst.SetTarget(targetObj.position, onHit);
        // Schedule the recharge method to be called after the specified period.
        Invoke(nameof(Recharge), period);
    }
    // Method to reset the drone to be ready for the next attack.
    private void Recharge() => readyForAttack = true;
}
