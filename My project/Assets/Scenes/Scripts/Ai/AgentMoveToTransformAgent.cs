using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMoveToTransformAgent : MonoBehaviour
{
    [SerializeField] private Transform MoveTo;
    [SerializeField] private NavMeshAgent agent;

    private void Update()
    {
        Vector3 pos = Vector3.down;
        agent.destination = PlayerLocatorSingleton.Instance.transform.position;
    }

}
