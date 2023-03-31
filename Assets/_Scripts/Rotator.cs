using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private bool x = true, y = true, z = true;
    [SerializeField] private float speed;
    private void FixedUpdate()
    {
        float step = speed * Time.fixedDeltaTime;
        transform.Rotate(x ? step : 0, y ? step : 0, z ? step : 0);
    }
}
