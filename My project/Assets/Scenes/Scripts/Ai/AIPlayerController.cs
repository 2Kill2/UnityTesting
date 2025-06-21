using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlexScripts;
using System.Threading;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
using UnityEngine.Animations;
using Unity.AI;

using UnityEngine.AI;

public class AIPlayerController : MonoBehaviour
{
    [SerializeField] private Transform waypointA;
    [SerializeField] private Transform waypointB;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] private PlayerLocatorSingleton playerLocator;

    //[SerializeField] private LayerMask DamageLayers;

    //vision

    [SerializeField] private float VisionRange = 10f;
    [SerializeField] private float VisionAngle = 45f; // in degrees
    [SerializeField] private LayerMask VisionLayers;
    [SerializeField] private EnemyBulletManager ebs;

    private int _currentHp;

    private void Start()
    {
        //_currentHp = MaxHp;
        Patrol();
    }

    /*private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == DamageLayers)
        {
            Debug.Log("Ai hit by bullet");
            _currentHp--;
            OnDamageTaken();
        }
    }*/

    /*private void OnDamageTaken()
    {
        float currentHpPercent = (float)_currentHp / MaxHp;
        HealthDisplay.UpdateHP(currentHpPercent);
    }*/

    private void Update()
    {
        Vector3 pos = Vector3.down; 
        // Check if player is in vision range and angle
        FindTarget();
    }
    private void Patrol()
    {
        //move vetween two points with delay when arriving at one
        //wait 3 seconds
        StartCoroutine(PatrolRoutine());
    }

    //CODE BELOW MAKES THE GUY MOVE BETWEEN POINTS AND WAIT 3 SECONDS PER POINT
    private IEnumerator PatrolRoutine()
    {
        while (true)
        {
            // Move to waypoint A
            agent.SetDestination(waypointA.position);
            yield return new WaitUntil(() => Vector3.Distance(transform.position, waypointA.position) < 1f);
            yield return new WaitForSeconds(3f); // Wait for 3 seconds
            // Move to waypoint B
            agent.SetDestination(waypointB.position);
            yield return new WaitUntil(() => Vector3.Distance(transform.position, waypointB.position) < 0.1f);
            yield return new WaitForSeconds(3f); // Wait for 3 seconds
        }
    }

    public LayerMask layerMask;
    private void FindTarget()
    {
        Debug.DrawRay(transform.position, PlayerLocatorSingleton.Instance.transform.position - transform.position + new Vector3(0f,1f, 0f), Color.red, 0.1f);
        if (Physics.Raycast(transform.position, PlayerLocatorSingleton.Instance.transform.position - transform.position + new Vector3(0f, 1f, 0f), out RaycastHit hit))
        {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            // Check if the hit object is the player
            if (hit.collider.gameObject == PlayerLocatorSingleton.Instance.gameObject)
            {

                // Player is within vision range and angle
                Debug.Log("Player detected!");
                // Implement logic to engage the player
                Chase();
                GetComponent<Renderer>().material.color = Color.yellow;
                StartCoroutine(ShootingRoutine());
                //ebs.Fire(PlayerLocatorSingleton.Instance.transform.position);
            }

            else
            {
                Debug.Log("Player out of angle range");
                GetComponent<Renderer>().material.color = Color.white;
                Patrol();
            }
        }
    }
        
    private IEnumerator ShootingRoutine()
    {
        // Wait for 1 second before shooting again
        yield return new WaitForSeconds(1f);
        // Fire the bullet
        ebs.Fire(PlayerLocatorSingleton.Instance.transform.position);
    }

    private void Chase()
    {
        // move to player for 3 seconds
        agent.SetDestination(PlayerLocatorSingleton.Instance.transform.position);
    }

}


