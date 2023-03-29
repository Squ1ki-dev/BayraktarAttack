using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
public partial class RivalsAI
{
    private void Patroling()
    {
        if (!walkPointSeted) SearchWalkPoint();

        if (walkPointSeted) MoveDroneToTarget(currentWalkPoint);

        if (Vector3.Distance(transform.position, currentWalkPoint) < 1f)
            walkPointSeted = false;
    }
    private void SearchWalkPoint()
    {
        currentWalkPoint = RandomTools.GetRandomPointInRange(transform.position, settings.walkRange, useY: false);

        if (!HasGrount())
            walkPointSeted = true;
    }
    private bool HasGrount() => Physics.Raycast(currentWalkPoint, -transform.up, Mathf.Infinity, settings.whatIsGround);
}
