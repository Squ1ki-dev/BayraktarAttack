using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Dron
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [SerializeField] private float _rotateSpeed;
    public void Move(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);

            _rigidbody.MovePosition(_rigidbody.position + (transform.forward * MoveSpeed * Time.fixedDeltaTime));
        }
    }
}
