using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Dron
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [SerializeField] private float _rotateSpeed, autoMovengSpeed;
    public void Move(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            var rotate = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotate, _rotateSpeed * Time.fixedDeltaTime);

            MoveForward(MoveSpeed);
        }
        else MoveForward(autoMovengSpeed);
    }
    public void MoveForward(float speed) =>_rigidbody.MovePosition(_rigidbody.position + (transform.forward * speed * Time.fixedDeltaTime));
}
