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
        {
            // dron.Move(transform.position.Direction(_walkPoint));
            agent.SetDestination(_walkPoint);
        }
            
        if (Vector3.Distance(transform.position, _walkPoint) < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        _walkPoint = RandomTools.GetRandomPointInRange(transform.position, _walkPointRange, useY: false);// new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (!HasGrount())
            walkPointSet = true;
    }
    private bool HasGrount() => Physics.Raycast(_walkPoint, -transform.up, Mathf.Infinity, whatIsGround);
    private void ChaseTarget() => agent.SetDestination(targetForAttack.position);
}
