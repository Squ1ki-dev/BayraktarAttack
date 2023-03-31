using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public partial class PlayerController
{
    public PlayerController(Joystick joystick, Dron drone, PlayerModel model)
    {
        this.joystick = joystick;
        this.drone = drone;
        this.model = model;
    }
    public Dron drone { get; private set; }
    public PlayerModel model { get; private set; }
    private Joystick joystick;
    public void Update()
    {
        drone.Move(new Vector3(joystick.Direction.x, 0, joystick.Direction.y));
        drone.ShootIfHasTarget(onHit: tank => model.Scores.value++);
    }
}
