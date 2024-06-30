using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    [SerializeField] Transform player;
    [SerializeField] LayerMask bossGround, ktoToPlayer;

    [SerializeField] float timeBetweenAttacks;
    bool alreadyAttacked;

    [SerializeField] float sightRange, attackRange;
    bool playerInSightRange, playerInAttackRange;

    [SerializeField] double hp = 200;

    [SerializeField] GameObject bossSpell;

    Vector2 smoothDeltaPosition;
    Vector2 velocity;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, ktoToPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, ktoToPlayer);

        if (playerInSightRange && !playerInAttackRange)
            Chase();
    }

    void Chase()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
        Debug.Log("Chasing player at position: " + player.position);
    }

    private void OnAnimatorMove()
    {
        // This will ensure we don't reset the position each frame
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            // Calculate the delta position before updating the transform's position
            Vector3 worldDeltaPosition = agent.velocity * Time.deltaTime;
            float deltaTime = Time.deltaTime;
            Vector3 localDeltaPosition = transform.InverseTransformVector(worldDeltaPosition);
            
            // Smoothly interpolate the delta position for smoother animation transitions
            smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, new Vector2(localDeltaPosition.x, localDeltaPosition.z), 0.5f);
            velocity = smoothDeltaPosition / deltaTime;
            
            Debug.Log("Current transform position: " + transform.position);
            Debug.Log("Velocity: " + velocity);
            
            // Update the animator parameters
            animator.SetFloat("locomotion", velocity.magnitude);
            
            // Use the animator's movement to move the character
            transform.position += worldDeltaPosition;
        }
    }
}
