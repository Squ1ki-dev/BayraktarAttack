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
    public EnemyState state;

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform tank;
    [SerializeField] private LayerMask whatIsGround, whatIsTarget;

    [Header("Patroling")]
    private bool walkPointSet;
    private Vector3 _walkPoint;
    [SerializeField] private float _walkPointRange;

    [Header("Attacking")]
    private bool alreadyAttacked;
    [SerializeField] private float _timeBetweenAttacks;
    [SerializeField] private GameObject _bulletPrefab;

    [Header("States")]
    [SerializeField] private float _sightRange, _attackRange;
    [SerializeField] private bool _targetInSightRange, _targetInAttackRange;

    private void Awake()
    {
        Transform tank = transform;
        agent = GetComponent<NavMeshAgent>();
        state = EnemyState.Patroling;
    }

    private void Update() => TargetInRange();

    private void TargetInRange()
    {
        _targetInSightRange = Physics.CheckSphere(transform.position, _sightRange, whatIsTarget);
        _targetInAttackRange = Physics.CheckSphere(transform.position, _attackRange, whatIsTarget);

        switch(state)
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

        if (_targetInSightRange)
        {
            state = EnemyState.Chasing;
            if (_targetInAttackRange)
                state = EnemyState.Attacking;
        }
        else
            state = EnemyState.Patroling;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _sightRange);
    }
}