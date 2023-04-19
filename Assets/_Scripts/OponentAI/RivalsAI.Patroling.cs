using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
public partial class RivalsAI
{
    private void Patroling()
    {
        if (!GameTools.HasGrount(currentWalkPoint, settings.whatIsGround))
            SearchNewWalkPoint();

        MoveDroneToTarget(currentWalkPoint);

        if (Vector3.Distance(transform.position, currentWalkPoint) < 5f)
            SearchNewWalkPoint();
    }
    private void SearchNewWalkPoint() => currentWalkPoint = RandomTools.GetRandomPointInRange(centrePoint, settings.walkRange, useY: false).WithY(transform.position.y);
}
