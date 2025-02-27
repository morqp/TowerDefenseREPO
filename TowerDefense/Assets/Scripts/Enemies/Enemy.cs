using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float speed = 12f;

    public GameObject destination;

    protected private NavMeshAgent agent;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = speed;

            if (destination != null)
            {
                Debug.Log("setting destination in enemy");
                agent.SetDestination(destination.transform.position);
                //agent.autoBraking= false;
                agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;

            }
        }
        else
        {
            Debug.LogWarning("NavMeshAgent component missing on " + this.gameObject.name);
        }
    }

    protected virtual void Update()
    {
        if (agent != null && !agent.pathPending)
        {
            //Debug.Log("agent remaining distance: " + agent.remainingDistance);
            if (agent.remainingDistance <= 1f)
            {
                Debug.Log("enemy reached destination");
                Die();
            }
        }
    }

    public void SetDestination(GameObject dest)
    {
        destination = dest;

        if (agent != null && destination != null)
        {
            agent.SetDestination(destination.transform.position);
        }

    }


    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log("enemy died");
        Destroy(this.gameObject);
    }
}
