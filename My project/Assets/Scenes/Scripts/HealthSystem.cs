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
        private void Awake()
        {
            currentHealth = maxHealth;
        }
        public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                Die();
            }
        }
        private void Die()
        {
            // Handle death logic here, e.g., play animation, destroy object, etc.
            Destroy(gameObject);
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
