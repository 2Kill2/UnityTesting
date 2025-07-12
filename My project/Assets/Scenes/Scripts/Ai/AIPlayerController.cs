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

public abstract class AIPlayerController : MonoBehaviour
{
    [SerializeField] private Transform waypointA;
    [SerializeField] private Transform waypointB;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] private PlayerLocatorSingleton playerLocator;

    [SerializeField] private LayerMask VisionLayers;
    [SerializeField] private EnemyBulletManager ebs;

    [SerializeField] protected AudioSource DetectSource;
    [SerializeField] protected AudioClip DetectSound;

    private int _currentHp;
    private float _currentCooldown;
    private float _ChaseDuration;

    private void Start()
    {
        //_currentHp = MaxHp;
        Patrol();
        CanFire = true;
        _currentCooldown = FireCooldown;
    }

    private void Update()
    {
        Vector3 pos = Vector3.down;
        // Check if player is in vision range and angle
        FindTarget();
        _currentCooldown -= Time.deltaTime;
        if (_currentCooldown <= 0)
        {
            CanFire = true;
            Debug.Log("CanFire Set True");

        }
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
        Debug.Log("FindTarget Called");
        Debug.DrawRay(transform.position, PlayerLocatorSingleton.Instance.transform.position - transform.position + new Vector3(0f, 1f, 0f), Color.red, 0.1f);
        if (Physics.Raycast(transform.position, PlayerLocatorSingleton.Instance.transform.position - transform.position + new Vector3(0f, 1f, 0f), out RaycastHit hit))
        {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            // Check if the hit object is the player
            if (hit.collider.gameObject == PlayerLocatorSingleton.Instance.gameObject)
            {
                if (CanFire)
                {
                    ShootingRoutine();
                    CanFire = false;
                    _currentCooldown = FireCooldown;
                }
                Debug.Log("Player detected!");
                GetComponent<Renderer>().material.color = Color.yellow;
                Chase();
                //if too close do RunAway
                float distanceToPlayer = Vector3.Distance(transform.position, PlayerLocatorSingleton.Instance.transform.position);
                if (distanceToPlayer < 2)
                {
                    RunAway();
                }
            }
            else
            {
                Debug.Log("Player out of angle range");
                GetComponent<Renderer>().material.color = Color.white;
                Patrol();
            }
        }
    }

    private bool CanFire;
    private float FireCooldown = 1f;
    private void CoolDown()
    {
        
        if (_currentCooldown <= 0)
        {
            CanFire = true;
            Debug.Log("CanFire Set True");
        }
    }
    


    private void ShootingRoutine()
    {
        // Fire the bullet
        ebs.Fire(PlayerLocatorSingleton.Instance.transform.position);
        Debug.Log("Fired from ShootingRoutine");
    }

    protected abstract void Chase();

    //Sniper things
    protected abstract void RunAway();

}


