using System.Collections;
using System.Collections.Generic;
using AlexScripts;
using UnityEngine;
namespace AlexScripts
{

    public class PhysicsBullet : MonoBehaviour
    {
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
            rb.AddForce(transform.forward * ProjectileSpeed, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            ContactPoint contact = collision.GetContact(0);
            bulletManager.OnProjectileCollision(contact.point, contact.normal);
            Destroy(gameObject);
        }

    }
}
