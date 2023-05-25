using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform quest;
    public NavMeshAgent agent;
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        
    }
    public void SetPosition(Transform quest)
    {
        agent.SetDestination(quest.position);
    }
}
