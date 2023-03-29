using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Dron : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private Transform view;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}
