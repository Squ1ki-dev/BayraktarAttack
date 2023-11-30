using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Partial definition of the 'Dron'(Base) class, inheriting from MonoBehaviour.
public partial class Dron : MonoBehaviour
{
    // Reference to the CharacterController component attached to the same GameObject.
    private CharacterController chController;

    // Serialized field for the view transform.
    [SerializeField] private Transform view;

    // Awake method called when the script instance is being loaded.
    private void Awake()
    {
        // Get the CharacterController component attached to the same GameObject.
        chController = GetComponent<CharacterController>();
    }
}
