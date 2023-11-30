using System.Collections;
using System.Collections.Generic;

// Importing the DG.Tweening and UnityEngine namespaces for tweening and Unity functionality.
using DG.Tweening;
using UnityEngine;

// Partial definition of the 'Dron' class.
public partial class Dron
{
//The [field: SerializeField] attribute is used here to specify that the attribute should be applied to the backing field of an auto-implemented property.
//In C#, when you declare a property using an auto-implemented property. The compiler automatically generates a backing field for the property.
//The [SerializeField] attribute is normally applied directly to fields, not properties.
// However, when you use auto-implemented properties, the field is generated implicitly by the compiler, and you don't have direct access to it in your code.
//The [field: SerializeField] attribute allows you to apply the [SerializeField] attribute to the generated backing field instead of the property itself.
// In this case, it ensures that the MoveSpeed property can be serialized by the Unity Editor even though the backing field is not directly visible in the code.
    
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
