using System.Collections;
using System.Collections.Generic;
using AlexScripts;
using UnityEngine;
namespace AlexScripts
{

    public class enemyBullet : MonoBehaviour
    {
        [SerializeField] HealthSystem healthSystem;
        [SerializeField] float ProjectileSpeed;
        [SerializeField] float ProjectileDamage;
        [SerializeField] Rigidbody rb;
        private BaseBulletManager bulletManager;

        public string PlayerTag = "Player";
        public string EnemyTag = "Enemy";
        public void Initialize(BaseBulletManager manager)
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
            if (collision.gameObject.CompareTag(EnemyTag))
            {
                return;
            }
            else
            {


                ContactPoint contact = collision.GetContact(0);
                bulletManager.OnProjectileCollision(contact.point, contact.normal);

                applyDamage(collision.gameObject);



                Destroy(gameObject);
            }
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
                return;
                //Debug.LogWarning("Target does not have a HealthSystem component.");
            }
        }

    }
}
