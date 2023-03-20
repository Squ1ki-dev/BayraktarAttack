using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    private void OnTriggerEnter(Collider other) 
    {
        Tank tank = other.GetComponent<Tank>();
        if(tank)
        {
            Instantiate(_bulletPrefab, _bulletSpawnPoint.position, Quaternion.identity);
            _bulletPrefab.GetComponent<Rigidbody>().velocity = -_bulletSpawnPoint.forward * _bulletSpeed;
        }
    }
}
