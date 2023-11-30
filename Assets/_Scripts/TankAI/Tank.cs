using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Importing the UnityEngine.AI namespace for NavMesh-related functionality.
using UnityEngine.AI;

// Partial definition of the 'Tank' class, inheriting from MonoBehaviour.
[RequireComponent(typeof(NavMeshAgent))]
public partial class Tank : MonoBehaviour
{
    // Reference to the NavMeshAgent attached to the same GameObject.
    public NavMeshAgent agent;
    
    // Radius of the sphere within which the tank can move randomly.
    public float range; //radius of sphere
    // Flag indicating whether the tank is stopped or not.
    public bool isStoped = false;
    // Transform representing the center point for random movement.
    public Transform centrePoint;


    // Serialized field for the explosion and fire particle system.
    [SerializeField] private ParticleSystem boomParticle, firePart;

    // Awake method called when the script instance is being loaded.
    private void Awake()
    {
        // Get the NavMeshAgent component attached to the same GameObject.
        agent = GetComponent<NavMeshAgent>();
    }

    // Update method called every frame.
    private void Update()
    {
        // Check if the tank is stopped; if so, return without further movement.
        if(isStoped) return;
        // Move the tank using the MoveTank method.
        MoveTank();
    }
    // Method to stop the tank's movement.
    public void Stop() => isStoped = true;
}
