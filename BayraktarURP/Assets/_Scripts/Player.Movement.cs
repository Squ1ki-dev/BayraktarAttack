using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = _joystick.Horizontal * _moveSpeed * Time.fixedDeltaTime;
        _moveVector.z = _joystick.Vertical * _moveSpeed * Time.fixedDeltaTime;

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _rotateSpeed * Time.fixedDeltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        if (_joystick.GetForce() != 0) _rigidbody.MovePosition(_rigidbody.position + (transform.forward * _moveSpeed * Time.fixedDeltaTime)); //* ((_joystick.Horizontal + _joystick.Vertical) / 2)));
    }
}
