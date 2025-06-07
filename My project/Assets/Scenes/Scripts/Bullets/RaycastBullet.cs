using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AlexScripts
{
    public class RaycastBullet : MonoBehaviour
    {
        [SerializeField] private ParticleSystem ParticleSystem;
        [SerializeField] private float Lifetime;
        [SerializeField] private float damage;
        private BulletManager bulletManager;
        private float _timer;

        public void Initialize(BulletManager manager)
        {
            bulletManager = manager;
        }

        private void Start()
        {
            GetComponent<HealthSystem>();
        }
        // Update is called once per frame
        void Update()
        {
            if (!ParticleSystem.IsAlive())
            {
                Destroy(gameObject);
            }
            _timer += Time.deltaTime;
            if (_timer >= Lifetime)
            {
                Destroy(gameObject);
            }
            
        }

        public void TargetObject(GameObject target)
        {

            var targetHealth = target.GetComponent<HealthSystem>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage);
            }
            else
            {
                Debug.LogWarning("Target does not have a HealthSystem component.");
            }
        }
        

    }

}
