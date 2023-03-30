using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class RivalsAI
{
    private void AttackTarget()
    {
        if (targetForAttack == null) return;
        MoveDroneToTarget(transform.position);
        dron.ShootIfHasTarget<Tank>(tank => model.Scores.value++);
    }
}
