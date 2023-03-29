using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public partial class PlayerController
{
    public PlayerController(Joystick joystick, Dron drone)
    {
        this.joystick = joystick;
        this.drone = drone;
    }
    private Dron drone;
    private Joystick joystick;
    public void Update()
    {
        drone.Move(joystick.Direction);
        drone.ShootIfHasTarget<Tank>();
    }
}
