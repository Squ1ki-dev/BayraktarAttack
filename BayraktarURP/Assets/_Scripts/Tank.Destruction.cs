using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Tank
{
    private void OnTriggerEnter(Collider other) 
    {
        Bullet bullet = other.GetComponent<Bullet>();
        
        if(bullet)
        {
            SpawnEnemy.Instance.EnemyKilled++;
            Destroy(gameObject);
        }
    }
}