using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private GameObject destination;

    void Start()
    {
        agent= GetComponent<NavMeshAgent>();

        agent.SetDestination(destination.transform.position);
    }

    void Update()
    {
        
    }
}
