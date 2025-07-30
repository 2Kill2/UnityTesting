using System.Collections;
using System.Collections.Generic;
using AlexScripts;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    protected override void Die()
    {
        ParticleSystem effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(DieSound);
        Destroy(gameObject);
    }
}
