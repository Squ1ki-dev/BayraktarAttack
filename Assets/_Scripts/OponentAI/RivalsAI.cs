using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Patroling,
    Chasing,
    Attacking
}

public partial class RivalsAI : MonoBehaviour
{
    public EnemyState currentState;
    [SerializeField] private Dron dron;
    [SerializeField] private NavMeshAgent agent;
    private Transform targetForAttack;
    [SerializeField] private LayerMask whatIsGround, whatIsTarget;

    [Header("Patroling")]
    private bool walkPointSet;
    private Vector3 _walkPoint;
    [SerializeField] private float _walkPointRange;

    [Header("Attacking")]
    private bool alreadyAttacked;
    [SerializeField] private float _timeBetweenAttacks;
    [SerializeField] private Bullet _bulletPrefab;

    [Header("States")]
    [SerializeField] private float _sightRange, _attackRange;

    private void Awake()
    {
        Transform tank = transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = dron.MoveSpeed;
    }

    private void Update()
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
    private void UpdateState()
    {
        RaycastHit hit;
        Physics.SphereCast(transform.position, _attackRange, Vector3.zero, out hit, whatIsTarget);
        targetForAttack = hit.transform;
        bool targetInSightRange = Physics.CheckSphere(transform.position, _sightRange, whatIsTarget);
        bool targetInAttackRange = targetForAttack != null;

        currentState = targetInSightRange ? (targetInAttackRange ? EnemyState.Attacking : EnemyState.Chasing) : EnemyState.Patroling;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _sightRange);
    }
}