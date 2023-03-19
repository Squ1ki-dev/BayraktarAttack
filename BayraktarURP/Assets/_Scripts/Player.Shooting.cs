using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    private void Shoot()
    {
        if(Physics.Raycast(transform.position, -Vector3.up, out _hit, 100f) && _hit.transform.tag == "Enemy")
        {
            var bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, Quaternion.identity);
        }
        else
            Debug.DrawRay(transform.position, _hit.point, Color.red);
    }
}
