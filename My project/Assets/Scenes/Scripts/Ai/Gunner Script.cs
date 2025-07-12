using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlexScripts;

public class GunnerScript : AIPlayerController
{
    protected override void Chase()
    {
        agent.SetDestination(PlayerLocatorSingleton.Instance.transform.position);
    }

    protected override void RunAway()
    {
        // implement strafing
        Vector3 directionToPlayer = PlayerLocatorSingleton.Instance.transform.position - transform.position;
        Vector3 runAwayDirection = transform.position - directionToPlayer.normalized * 5f; // Move away from the player
        agent.SetDestination(runAwayDirection);
        Vector3 lateralMovement = Vector3.Cross(directionToPlayer, Vector3.up).normalized * 2f; // Move laterally
        agent.SetDestination(runAwayDirection + lateralMovement);


    }
}
