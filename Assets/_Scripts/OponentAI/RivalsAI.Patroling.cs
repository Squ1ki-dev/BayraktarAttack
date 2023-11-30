using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
// Partial definition of the 'RivalsAI'(Patroling) class.
public partial class RivalsAI
{
    // Method to handle patrolling behavior.
    private void Patroling()
    {
        // Check if the current walk point is not on the ground; if not, search for a new walk point.
        if (!GameTools.HasGrount(currentWalkPoint, settings.whatIsGround))
            SearchNewWalkPoint();
        // Move the drone towards the current walk point.
        MoveDroneToTarget(currentWalkPoint);
        // If the drone is close to the current walk point, search for a new one.
        if (Vector3.Distance(transform.position, currentWalkPoint) < 5f)
            SearchNewWalkPoint();
    }
    // Method to search for a new walk point within the specified range around the center point.
    private void SearchNewWalkPoint() => currentWalkPoint = RandomTools.GetRandomPointInRange(centrePoint, settings.walkRange, useY: false).WithY(transform.position.y);
}
