using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public partial class PlayerController : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Dron dron;
    private void FixedUpdate()
    {
        dron.Move(_joystick.Direction);
        dron.TrySpawnBullet(Time.fixedDeltaTime);
    }
}
