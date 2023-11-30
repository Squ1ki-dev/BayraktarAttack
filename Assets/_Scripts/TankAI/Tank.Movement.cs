using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Importing the UnityEngine.AI namespace for NavMesh-related functionality.
using UnityEngine.AI;

// Partial definition of the 'Tank'(Movement) class.
public partial class Tank
{
    // Method to generate a random point within a specified range on the NavMesh.
    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        NavMeshHit hit;
        // Generate a random point within a sphere around the center.
        Vector3 randomPoint = center + Random.insideUnitSphere * range;

        // Check if the random point is on the NavMesh.
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true; // Return true if a valid point is found.
        }

        result = Vector3.zero;
        return false; // Return false if a valid point is not found.
    }
    
    // Method to move the tank to a random point within a specified range.
    private void MoveTank()
    {
        // Attempt to find a random point around the specified center within the range.
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;
            
            // Attempt to find a random point around the specified center within the range.
            if (RandomPoint(centrePoint.position, range, out point))
            {
                // Draw a debug ray to visualize the selected point.
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                // Set the tank's destination to the randomly selected point.
                agent.SetDestination(point);
            }
        }
    }
}
