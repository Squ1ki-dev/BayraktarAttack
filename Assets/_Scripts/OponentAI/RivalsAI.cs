using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Patroling,
    Attacking
}
[System.Serializable]
public struct RivalsAISettings
{
    public LayerMask whatIsGround, whatIsTarget;
    public float walkRange, attackRange;
}
public partial class RivalsAI
{
    public EnemyState currentState;
    private Dron dron;
    private Transform targetForAttack;
    private Vector3 currentWalkPoint;
    Transform transform => dron.transform;
    RivalsAISettings settings;
    public PlayerModel model { get; private set; }
    Vector3 centrePoint;
    public RivalsAI(PlayerModel model, RivalsAISettings settings, Dron drone, Vector3 centrePoint)
    {
        this.model = model;
        this.settings = settings;
        this.dron = drone;
        this.centrePoint = centrePoint;
    }
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
            case EnemyState.Attacking:
                AttackTarget();
                break;
        }
    }

    private void MoveDroneToTarget(Vector3 target) => dron.Move(transform.position.Direction(target).WithY(0));

    private void UpdateState()
    {
        foreach (var hit in Physics.OverlapSphere(transform.position, settings.attackRange, settings.whatIsTarget))
        {
            targetForAttack = hit.transform;
            break;
        }

        // RaycastHit hit;
        // Physics.SphereCast(transform.position, settings._attackRange, Vector3.zero, out hit, settings.whatIsTarget);

        // Physics.CheckSphere(transform.position, settings.attackRange, settings.whatIsTarget);

        bool targetInAttackRange = targetForAttack != null;

        currentState = targetInAttackRange ? EnemyState.Attacking : EnemyState.Patroling;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, settings.attackRange);
    }
}