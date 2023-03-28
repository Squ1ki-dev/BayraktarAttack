using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Dron
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [SerializeField] private float _rotateSpeed;
    private Vector3 _moveVector;
    public void Move(Vector2 moveDirection)
    {
        _moveVector = Vector3.zero;
        _moveVector.x = moveDirection.x * MoveSpeed * Time.fixedDeltaTime;
        _moveVector.z = moveDirection.y * MoveSpeed * Time.fixedDeltaTime;

        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _rotateSpeed * Time.fixedDeltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        if (moveDirection != Vector2.zero) _rigidbody.MovePosition(_rigidbody.position + (transform.forward * MoveSpeed * Time.fixedDeltaTime)); //* ((_joystick.Horizontal + _joystick.Vertical) / 2)));
    }
}
