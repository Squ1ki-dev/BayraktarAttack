using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public partial class Player : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;

    private RaycastHit _hit;

    private Rigidbody _rigidbody;
    private Vector3 _moveVector;

    private void Awake() 
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        Move();
    }
}
