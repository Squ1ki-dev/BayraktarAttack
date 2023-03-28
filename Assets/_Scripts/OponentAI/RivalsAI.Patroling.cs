using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
public partial class RivalsAI
{
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(_walkPoint);

        Vector3 distanceToWalkPoint = transform.position - _walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range

        _walkPoint = RandomTools.GetRandomPointInSphere(transform.position, _walkPointRange, useY: false);// new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(_walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChaseTarget() => agent.SetDestination(tank.position);
}
