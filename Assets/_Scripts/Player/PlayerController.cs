using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Require a Rigidbody component to be attached to the same GameObject as this script.
[RequireComponent(typeof(Rigidbody))]
public partial class PlayerController
{
    // Constructor for the PlayerController class, initializing with a Joystick, Dron, and PlayerModel.
    public PlayerController(Joystick joystick, Dron drone, PlayerModel model)
    {
        this.joystick = joystick;
        this.drone = drone;
        this.model = model;
    }
    // Public property to get the drone instance; private set to restrict external modification.
    public Dron drone { get; private set; }
        // Public property to get the player model instance; private set to restrict external modification.
    public PlayerModel model { get; private set; }
    // Private variable to store a reference to the Joystick.
    private Joystick joystick;

    // Method to stop the drone's movement.
    public void Stop()
    {
        drone.Stop();
    }
    
    // Method to update the player's state.
    public void Update()
    {
        // Move the drone based on the joystick's direction.
        drone.Move(new Vector3(joystick.Direction.x, 0, joystick.Direction.y));

        // If the drone has a target, shoot and increment the player's score
        drone.ShootIfHasTarget(onHit: tank => model.Scores.value++);
    }
}
