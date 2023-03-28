using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class RivalsAI
{
    private void AttackTarget()
    {
        if(targetForAttack == null) return;
        // Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        // Calculate direction to player
        Vector3 directionToTank = transform.position.Direction(targetForAttack.position).WithY(0);

        transform.rotation = Quaternion.LookRotation(directionToTank);

        if (!alreadyAttacked)
        {
            // Attack code here
            var bullet = Instantiate(_bulletPrefab, transform.position + directionToTank.normalized * 2f, Quaternion.identity);
            bullet.SetTarget(targetForAttack.position);
            // End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), _timeBetweenAttacks);
        }
    }

    private void ResetAttack() => alreadyAttacked = false;
}
