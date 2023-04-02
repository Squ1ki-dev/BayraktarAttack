using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Dron : MonoBehaviour
{
    private CharacterController chController;
    [SerializeField] private Transform view;
    private void Awake()
    {
        chController = GetComponent<CharacterController>();
    }
}
