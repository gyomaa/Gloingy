using UnityEngine.AI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float Distance;

    public bool isAngered;

    public NavMeshAgent _agent;

    private void Start()
    {
        
    }

    private void Update()
    {
        Distance = Vector3.Distance(player.transform.position, this.transform.position);
        
        if (Distance <= 20f)
        {
            isAngered = true;
        }
        if (Distance > 20f)
        {
            isAngered = false;
        }

        if (isAngered)
        {
            _agent.isStopped = false; 

            _agent.SetDestination(player.transform.position);
        }
        if (!isAngered)
        {
            _agent.isStopped = true;
        }
    }

    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
