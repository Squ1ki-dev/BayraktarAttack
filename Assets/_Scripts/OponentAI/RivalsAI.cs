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
    private Tank targetForAttack;
    private Vector3 currentWalkPoint;
    Transform transform => dron.transform;
    RivalsAISettings settings;
    public PlayerModel model { get; private set; }
    Vector3 centrePoint;
    public void Stop()
    {
        dron.Stop();
    }
    public RivalsAI(PlayerModel model, RivalsAISettings settings, Dron drone, Vector3 centrePoint)
    {
        this.model = model;
        this.settings = settings;
        this.dron = drone;
        this.centrePoint = centrePoint;
        dron.targetObj.transform.SetActive(false);
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
            var temp = hit.transform.GetComponent<Tank>();
            if (hit.transform.position.y > transform.position.y || temp.IsDead) continue;
            targetForAttack = temp;

            break;
        }

        bool targetInAttackRange = targetForAttack != null;

        currentState = targetInAttackRange ? EnemyState.Attacking : EnemyState.Patroling;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, settings.attackRange);
    }
}