using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlexScripts;

public class SniperScript : AIPlayerController
{
    protected override void Chase()
    {
        // Snipers typically maintain a distance, so they might not chase directly
        // Instead, they might find a vantage point or stay at a distance
        // For simplicity, let's assume the sniper will just look at the player
        Vector3 directionToPlayer = PlayerLocatorSingleton.Instance.transform.position - transform.position;   
        agent.SetDestination(transform.position + directionToPlayer.normalized * 10f); // Move towards the player but maintain distance
        //agent.SetDestination(PlayerLocatorSingleton.Instance.transform.position);
    }

    protected override void RunAway()
    {
        //make the sniper run away from the player
        Vector3 directionToPlayer = PlayerLocatorSingleton.Instance.transform.position - transform.position;
        Vector3 runAwayDirection = transform.position - directionToPlayer.normalized * 5f; // Move away from the player
        agent.SetDestination(runAwayDirection);
    }
}
