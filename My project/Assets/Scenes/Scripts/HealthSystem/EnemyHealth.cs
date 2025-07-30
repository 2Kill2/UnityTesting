using System.Collections;
using System.Collections.Generic;
using AlexScripts;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    [SerializeField] private Color defaultColor; // Fixed CS0106 by moving the attribute inside the class and corrected casing for consistency.  

    private void Start()
    {
        //defaultColor = gameObject.GetComponent<Renderer>().material.color;
    }

    protected override void Die()
    {
        ParticleSystem effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(DieSound);
        Destroy(gameObject);
    }
}
