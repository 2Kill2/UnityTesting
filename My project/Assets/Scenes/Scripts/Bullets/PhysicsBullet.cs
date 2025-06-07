using System.Collections;
using System.Collections.Generic;
using AlexScripts;
using UnityEngine;
namespace AlexScripts
{

    public class PhysicsBullet : MonoBehaviour
    {
        [SerializeField] HealthSystem healthSystem;
        [SerializeField] float ProjectileSpeed;
        [SerializeField] float ProjectileDamage;
        [SerializeField] Rigidbody rb;
        private BulletManager bulletManager;

        public void Initialize(BulletManager manager)
        {
            bulletManager = manager;
        }

        void Start()
        {
            GetComponent<HealthSystem>();
            rb.AddForce(transform.forward * ProjectileSpeed, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            ContactPoint contact = collision.GetContact(0);
            bulletManager.OnProjectileCollision(contact.point, contact.normal);

            applyDamage(collision.gameObject);



            Destroy(gameObject);
        }

        private void applyDamage(GameObject target)
        {

            var targetHealth = target.GetComponent<HealthSystem>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(ProjectileDamage);
            }
            else
            {
                Debug.LogWarning("Target does not have a HealthSystem component.");
            }
        }

    }
}
