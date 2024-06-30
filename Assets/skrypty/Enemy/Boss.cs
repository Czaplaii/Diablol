using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] LayerMask bossGround, ktoToPlayer;

    [SerializeField] float timeBetweenAttacks;
    bool alreadyAttacked;

    [SerializeField] float sightRange, attackRange;
    bool playerInSightRange, playerInAttackRange;

    [SerializeField] double hp = 200;

    [SerializeField] GameObject bossSpell;

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, ktoToPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, ktoToPlayer);

        if (playerInSightRange && !playerInAttackRange) Chase();
    }

    void Chase()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }
}
