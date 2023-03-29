using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Patroling,
    Chasing,
    Attacking
}
public struct RivalsAISettings
{
    public LayerMask whatIsGround, whatIsTarget;
    public float walkRange, _sightRange, _attackRange;
}
public partial class RivalsAI
{
    public EnemyState currentState;
    private Dron dron;
    private Transform targetForAttack;
    private bool walkPointSeted;
    private Vector3 currentWalkPoint;
    Transform transform => dron.transform;
    RivalsAISettings settings;
    public void SetDrone(Dron drone) => this.dron = drone;

    public void SetSettings(RivalsAISettings settings) => this.settings = settings;

    public void Update()
    {
        UpdateState();
        Move();
    }

    private void Move()
    {
        switch (currentState)
        {
            case EnemyState.Patroling:
                Patroling();
                break;
            case EnemyState.Chasing:
                ChaseTarget();
                break;
            case EnemyState.Attacking:
                AttackTarget();
                break;
        }
    }
    
    private void MoveDroneToTarget(Vector3 target) => dron.Move(transform.position.Direction(target));

    private void UpdateState()
    {
        RaycastHit hit;
        Physics.SphereCast(transform.position, settings._attackRange, Vector3.zero, out hit, settings.whatIsTarget);
        targetForAttack = hit.transform;
        bool targetInSightRange = Physics.CheckSphere(transform.position, settings._sightRange, settings.whatIsTarget);
        bool targetInAttackRange = targetForAttack != null;

        currentState = targetInSightRange ? (targetInAttackRange ? EnemyState.Attacking : EnemyState.Chasing) : EnemyState.Patroling;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, settings._attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, settings._sightRange);
    }
}