using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexScripts
{

    [SerializeField]
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float currentHealth;
        [SerializeField] private Color defaultcolor;
        [SerializeField] private AudioClip hitSound;
        [SerializeField] private ParticleSystem deathEffect;
        [SerializeField] private AudioClip DieSound; 
        private void Start()
        {
            currentHealth = maxHealth;
            defaultcolor = gameObject.GetComponent<Renderer>().material.color;
        }

        private void Update()
        {
            if (currentHealth <= 0)
            {
                Die();
            }
        }
        public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            hitflash();
            //activate hit marker & sound
            //AudioSource.PlayOneShot(hitSound);
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void hitflash() 
        {
            //make flash red
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            //wait 0.1 seconds
            StartCoroutine(ResetColor());
        }

        private IEnumerator ResetColor()
        {
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<Renderer>().material.color = defaultcolor;
        }
        private void Die()
        {

            //AudioSource.PlayOneShot(DieSound);
            ParticleSystem effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            //make a puff of smoke, maybe they fall down or smth
        }
        public float GetCurrentHealth()
        {
            return currentHealth;
        }
        public float GetMaxHealth()
        {
            return maxHealth;
        }
    }
}
