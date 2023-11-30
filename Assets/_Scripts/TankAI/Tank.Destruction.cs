using System;
using System.Collections;
using System.Collections.Generic;
// Importing the 'Tools' namespace for additional functionality.
using Tools;
using UnityEngine;
using UnityEngine.Events;

// Partial definition of the 'Tank'(Destruction) class.
public partial class Tank
{
    // Event triggered when the tank's life changes.
    public UnityEvent<Tank> onLife = new();
    // Property indicating whether the tank is dead or not; private set to restrict external modification.
    public bool IsDead { get; private set; }

    // Method to simulate the tank being destroyed.
    public void Kill()
    {
        // Trigger particle effect for explosion.
        boomParticle.Play();
        // Activate and play the fire particle effect.
        firePart.SetActive(true);
        firePart.Play();
        // Set the tank's state to dead.
        IsDead = true;
        // Disable NavMeshAgent updates for position and rotation.
        agent.updatePosition = false;
        agent.updateRotation = false;
        // Wait for the duration of the explosion particle effect.
        this.Wait(boomParticle.main.duration, () =>
        {
            // Invoke the 'onLife' event with the current tank instance.
            onLife.Invoke(this);
            
            // Stop and deactivate the fire particle effect.
            firePart.Stop();
            firePart.SetActive(false);
            
            // Enable NavMeshAgent updates for position and rotation.
            agent.updatePosition = true;
            agent.updateRotation = true;
            
            // Set the tank's state to not dead.
            IsDead = false;
        });

    }
}
