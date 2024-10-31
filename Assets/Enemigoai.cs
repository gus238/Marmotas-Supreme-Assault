using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIMovement : MonoBehaviour
{
    // Reference of target to follow to activate the enemy
    [SerializeField] Transform Target;

    // Caching of NavMeshAgent for easier use
    NavMeshAgent navMeshAgent;
    // Caching player health component (replace with appropriate health script if not found)
    BarraDeVida targetHealth;
    // Caching enemy health component (replace with appropriate health script if not found)
    VidaEnemigo enemyHealth;

    // The range between target and enemy to activate the enemy
    [SerializeField] float Range = 10f;
    float distanceToTarget = Mathf.Infinity;

    // Health and Speed characteristics of enemy
    [SerializeField] public float Damage = 10f;
    [SerializeField] float turningSpeed = 5f;
    [SerializeField] public float attackCooldown = 1.5f;
    float lastAttackTime = -Mathf.Infinity;

    // Bool to know whether the enemy is activated or not
    public bool isProvoked = false;

    // Bool to know whether the enemy is alive or not
    bool dead;

    // Animator reference for animations
    Animator animator;

    void Start()
    {
        // Caching navMeshAgent, Animator, PlayerHealth, and EnemyHealth
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        // Ensure to have a script named 'BarraDeVida' or replace with the correct health script
        targetHealth = Target.GetComponent<BarraDeVida>();
        // Ensure to have a script named 'VidaEnemigo' or replace with the correct health script
        enemyHealth = GetComponent<VidaEnemigo>();
    }

    void Update()
    {
        // Checking whether the enemy is still alive
        dead = enemyHealth.IsDead();
        if (dead)
        {
            Die();
            return;
        }

        // Only calculate distance if the enemy is not provoked
        if (!isProvoked)
        {
            distanceToTarget = Vector3.Distance(Target.position, transform.position);
        }

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= Range)
        {
            // If the target entered the range then activate
            isProvoked = true;
        }
    }

    // Movement Function
    private void EngageTarget()
    {
        // Look at direction of target function
        LookTarget();

        // Compare distance to target and stopping distance that assigned in navmesh agent in target.
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            // If enemy hasn't reached the stopping condition, move towards target
            if (navMeshAgent.isOnNavMesh && navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                navMeshAgent.SetDestination(Target.position);
                animator.SetBool("isMoving", true);
            }
        }
        else
        {
            // If the enemy is within stopping distance, attack target
            AttackTarget();
        }
    }

    // Look in direction of target
    private void LookTarget()
    {
        // Calculate new direction vector from target's position to enemy's position
        Vector3 direction = (Target.position - transform.position).normalized;

        // Make new quaternion with the new direction vector we calculated to assign that to the enemy's rotation
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        // Assign the created quaternion to the enemy
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turningSpeed);
    }

    // Attack Function
    private void AttackTarget()
    {
        animator.SetBool("isMoving", false);
        if (Time.time > lastAttackTime + attackCooldown)
        {
            // Attack animation trigger
            animator.SetTrigger("attack");
            // Logic to damage target
            targetHealth.ReducirVida(Damage);
            lastAttackTime = Time.time;
        }
    }

    // Function to handle enemy death
    private void Die()
    {
        navMeshAgent.enabled = false;
        animator.SetTrigger("die");
        // Disable further actions when dead
        this.enabled = false;
    }

    // Gizmos to give a visual representation of range for debugging process
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
