using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace AlexScripts
{

    [SerializeField]
    public abstract class HealthSystem : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float currentHealth;
        [SerializeField] private Color defaultcolor;
        [SerializeField] private AudioClip hitSound;
        [SerializeField] protected ParticleSystem deathEffect;
        [SerializeField] protected AudioClip DieSound;
        [SerializeField] protected Canvas deathScreen;
        [SerializeField] protected PlayerInputScript Inputs;
        [SerializeField] protected AudioSource audioSource;
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


        protected abstract void Die();
       
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
