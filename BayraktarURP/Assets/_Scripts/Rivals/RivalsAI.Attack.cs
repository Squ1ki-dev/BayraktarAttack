using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class RivalsAI
{
    // private void AttackTarget()
    // {
    //     agent.SetDestination(transform.position);

    //     transform.LookAt(tank);

    //     if (!alreadyAttacked)
    //     {
    //         ///Attack code here
    //         Rigidbody rb = Instantiate(_bulletPrefab, transform.position, transform.rotation).GetComponent<Rigidbody>();
    //         rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
    //         rb.AddForce(transform.up * 8f, ForceMode.Impulse);

    //         alreadyAttacked = true;
    //         Invoke(nameof(ResetAttack), _timeBetweenAttacks);
    //     }
    // }

    private void AttackTarget()
    {
        // Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        // Calculate direction to player
        Vector3 directionToTank = tank.position - transform.position;
        directionToTank.y = 0f;

        transform.rotation = Quaternion.LookRotation(directionToTank);

        if (!alreadyAttacked)
        {
            // Attack code here
            Rigidbody rb = Instantiate(_bulletPrefab, transform.position + directionToTank.normalized * 2f, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(directionToTank.normalized * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            // End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), _timeBetweenAttacks);
        }
    }

    private void ResetAttack() => alreadyAttacked = false;
}
