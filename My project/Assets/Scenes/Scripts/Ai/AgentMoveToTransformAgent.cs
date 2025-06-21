using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMoveToTransformAgent : MonoBehaviour
{
    [SerializeField] private Transform moveTarget;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private PlayerLocatorSingleton playerLocator;

    private void Update()
    {
        Vector3 pos = Vector3.down;
    }

    private void OnEnable()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        if (moveTarget != null)
        {
            agent.SetDestination(moveTarget.position);
        }
    }

    public void MoveTo()
    {
        if (moveTarget != null)
        {
            agent.SetDestination(moveTarget.position);
        }
        else if (playerLocator != null && playerLocator.transform != null)
        {
            agent.SetDestination(playerLocator.transform.position);
        }
        else
        {
            Debug.LogWarning("No move target or player locator set.");
        }
    }

}
