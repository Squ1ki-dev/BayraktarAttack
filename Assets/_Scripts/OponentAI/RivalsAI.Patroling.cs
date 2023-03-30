using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
public partial class RivalsAI
{
    private void Patroling()
    {
        if (!GameTools.HasGrount(currentWalkPoint, GameConfigs.Instance.settings.rivalsAISettings.whatIsGround))
            SearchNewWalkPoint();

        MoveDroneToTarget(currentWalkPoint);

        if (Vector3.Distance(transform.position, currentWalkPoint) < 2f)
            SearchNewWalkPoint();
    }
    private void SearchNewWalkPoint() => currentWalkPoint = RandomTools.GetRandomPointInRange(centrePoint, settings.walkRange, useY: false).WithY(transform.position.y);
}
