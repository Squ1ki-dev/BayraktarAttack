using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class RivalsAI
{
    // Method to handle attacking behavior.
    private void AttackTarget()
    {
        // Check if the target for attack is dead; if so, reset the target.
        if(targetForAttack.IsDead) targetForAttack = null;

        // If there is no valid target, return without further action.
        if (targetForAttack == null) return;

        // Move the drone towards the position of the target tank.
        MoveDroneToTarget(targetForAttack.transform.position);

        // Attempt to shoot at the target tank.
        dron.ShootIfHasTarget(tank =>
        {
            // Reset the target after successfully shooting, and increment the player's score.
            targetForAttack = null;
            model.Scores.value++;
        });
    }
}
