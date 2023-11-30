using System.Collections;
using System.Collections.Generic;

// Importing the DG.Tweening and UnityEngine namespaces for tweening and Unity functionality.
using DG.Tweening;
using UnityEngine;

// Partial definition of the 'Dron' class.
public partial class Dron
{
    // Serialized field for the movement speed of the drone.
    [field: SerializeField] public float MoveSpeed { get; private set; }
    // Serialized field for the rotation speed and autoMovingSpeed of the drone. 
    [SerializeField] private float _rotateSpeed, autoMovengSpeed;

    // Boolean flag indicating whether the drone is stopped.
    bool isStoped = false;
    
    // Method to stop the drone's movement.
    public void Stop() => isStoped = true;
    // Method to handle the movement of the drone based on the provided direction.
    public void Move(Vector3 moveDirection)
    {
        // If the drone is stopped, return without further movement.
        if(isStoped) return;

        // If the move direction is not zero, rotate the drone and move forward.
        if (moveDirection != Vector3.zero)
        {
            // Calculate the rotation to face the move direction.
            var rotate = Quaternion.LookRotation(moveDirection);
            // Smoothly interpolate the rotation of the drone.
            transform.rotation = Quaternion.Lerp(transform.rotation, rotate, _rotateSpeed * Time.fixedDeltaTime);
            // Move the drone forward.
            MoveForward(MoveSpeed);
        }
        else MoveForward(autoMovengSpeed); // If the move direction is zero, move the drone forward automatically.
    }
    // Method to move the drone forward with a specified speed.
    public void MoveForward(float speed)
    {
        // If the CharacterController component is not present, return without movement.
        if (chController == null) return;
        // Move the drone using the CharacterController component.
        chController.Move((transform.forward * speed * Time.fixedDeltaTime));
    }
}
