using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        Bullet bullet = other.GetComponent<Bullet>();

        if(bullet)
            Destroy(gameObject);
    }
}
