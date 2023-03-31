using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class RivalsAI
{
    private void AttackTarget()
    {
        if (targetForAttack == null) return;
        MoveDroneToTarget(targetForAttack.position);
        dron.ShootIfHasTarget(tank =>
        {
            targetForAttack = null;
            model.Scores.value++;
        });
    }
}
