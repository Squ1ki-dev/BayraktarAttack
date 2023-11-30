using UnityEngine;
using UnityEngine.AI;
// Enumeration representing the possible states of the enemy AI.
public enum EnemyState
{
    Patroling,
    Attacking
}
// Serializable struct containing settings for the rival AI.
[System.Serializable]
public struct RivalsAISettings
{
    public LayerMask whatIsGround, whatIsTarget;
    public float walkRange, attackRange;
}
// Partial definition of the 'RivalsAI'(Base) class.
public partial class RivalsAI
{
    // Current state of the enemy AI.
    public EnemyState currentState;
    // Reference to the drone controlled by the AI.
    private Dron dron;
    // Target tank for the AI to attack.
    private Tank targetForAttack;
    // Current walk point for patrolling.
    private Vector3 currentWalkPoint;
    // Property returning the transform of the drone.
    Transform transform => dron.transform;
    // Settings for the rival AI.
    RivalsAISettings settings;
    // Reference to the player model.
    public PlayerModel model { get; private set; }
    // Center point for AI movement.
    Vector3 centrePoint;
    // Method to stop the drone's movement.
    public void Stop()
    {
        dron.Stop();
    }

    // Constructor for the RivalsAI class, initializing with a player model, settings, drone, and center point.
    public RivalsAI(PlayerModel model, RivalsAISettings settings, Dron drone, Vector3 centrePoint)
    {
        this.model = model;
        this.settings = settings;
        this.dron = drone;
        this.centrePoint = centrePoint;
        // Deactivate the target object of the drone.
        dron.targetObj.transform.SetActive(false);
    }

    // Method to update the AI's state and movement.
    public void Update()
    {
        UpdateState();
        Move();
    }
    
    // Method to move the drone based on the current state.
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
    // Method to move the drone towards a target position.
    private void MoveDroneToTarget(Vector3 target) => dron.Move(transform.position.Direction(target).WithY(0));
    // Method to update the AI's state based on nearby targets.
    private void UpdateState()
    {
        // Check for nearby targets within the attack range.
        foreach (var hit in Physics.OverlapSphere(transform.position, settings.attackRange, settings.whatIsTarget))
        {
            // Get the Tank component from the hit object.
            var temp = hit.transform.GetComponent<Tank>();
            // Skip if the target is above the AI or is already dead.
            if (hit.transform.position.y > transform.position.y || temp.IsDead) continue;
            // Set the target for attack and break from the loop.
            targetForAttack = temp;

            break;
        }
        // Check if there is a target within attack range.
        bool targetInAttackRange = targetForAttack != null;
        // Set the AI state based on the target's presence.
        currentState = targetInAttackRange ? EnemyState.Attacking : EnemyState.Patroling;
    }
    // Method to draw a visual representation of the attack range in the scene view.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, settings.attackRange);
    }
}
