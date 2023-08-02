using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
   
    float closeCombatDistance = 2f;
    public float damageAmount = 10f;

    bool isAttacking = false;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if(!isAttacking)
        {

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if(distanceToPlayer < closeCombatDistance)
            {
                agent.SetDestination(player.position);
            }
            else
            {
                agent.ResetPath();
                isAttacking = true;
                AttackPlayer();
            } 

        }
    }

    private void AttackPlayer()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
    }
}
